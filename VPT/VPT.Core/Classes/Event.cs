using System.Globalization;
using VPT.Core.Dto_s;

namespace VPT.Core.Classes;

public class Event
{
    private static readonly Random rnd = new Random();
    public string name { get; private set; }
    public DateTime lastRegisterTime { get; private set; }
    public DateTime eventStart { get; private set; }
    public int spaces { get; private set; }
    public List<block> blocklist { get; private set; }
    public List<reservation> applicationList { get; private set; }
    private int spacesLeft { get; set; }

    public Event(DtoEvent Dto)
    {
        name = Dto.name;
        lastRegisterTime = Dto.lastRegisterTime;
        eventStart = Dto.eventStart;
        spaces = Dto.spaces;
        blocklist = Dto.blocklist;
        applicationList = Dto.applicationList;

        this.spacesLeft = this.spaces;
    }

    public Event(DateTime lastRegisterTime, DateTime eventStart, int spaces, List<reservation> applicationList, string name)
    {
        this.lastRegisterTime = lastRegisterTime;
        this.eventStart = eventStart;
        this.spaces = spaces;
        this.blocklist = new();
        this.applicationList = new();
        this.name = name;

        this.spacesLeft = this.spaces;
    }

    public Event(DateTime lastRegisterTime, DateTime eventStart, int spaces, List<block> blocklist, List<reservation> applicationList, string name)
    {
        this.lastRegisterTime = lastRegisterTime;
        this.eventStart = eventStart;
        this.spaces = spaces;
        this.blocklist = blocklist;
        this.applicationList = applicationList;
        this.name = name;

        this.spacesLeft = this.spaces;
    }

    private bool CanAddReservation(DtoReservation dto)
    {
        if (dto.time > lastRegisterTime)
            throw new Exception("cant register after register close");
        if (dto.group == null)
            throw new Exception("cant register without group");
        if (new group(dto.group).GetAdultAmount()! > 0 && new group(dto.group).GetChildrenAmount() > 0)
            throw new Exception("cant have a group with only children");
        return true;
    }

    public void AddReservation(DtoReservation dto)
    {
        if (CanAddReservation(dto))
            applicationList.Add(new(dto));
        else
            throw new Exception("cant add reservation");
    }

    public void AddReservations(List<DtoReservation> dto)
    {
        foreach (DtoReservation r in dto)
            AddReservation(r);
    }

    private void MakeRandomBlocks()
    {
        char blockName = 'A';
        char blockName2 = 'A';
        char blockName3 = 'A';
        int rowName = 0;
        int chairName = 0;

        while (spacesLeft >= 30)
        {
            int ChairAmount = rnd.Next(3, 10);
            int RowAmount = rnd.Next(1, 3);
            List<row> newRowList = new();
            for (int i = 0; i < RowAmount; i++)
            {
                List<chair> newChairList = new();
                for (int j = 0; j < ChairAmount; j++)
                {
                    chair newChair = new(blockName + rowName + "-" + chairName);
                    newChairList.Add(newChair);
                    chairName++;
                }
                row newRow = new(newChairList, rowName);
                newRowList.Add(newRow);
                rowName++;
            }
            block newBlock;
            if (blockName <= 'Z')
            {
                newBlock = new(newRowList, blockName.ToString());
                blockName++;
            }
            else if (blockName2 <= 'Z')
            {
                newBlock = new(newRowList, (blockName + blockName2).ToString());
                blockName2++;
            }
            else
            {
                newBlock = new(newRowList, (blockName + blockName2 + blockName3).ToString());
                blockName3++;
            }
            blocklist.Add(newBlock);
        }
    }

    private void MakeBlock(int children ,double visitors, string blockName)
    {
        int rowName = 0;
        int chairName = 0;

        int RowAmount = (int)Math.Ceiling(visitors / 10);
        int ChairAmount = (int)Math.Ceiling(visitors / RowAmount);

        if (children > ChairAmount)
        {
            if (children !> 9)
            {
                ChairAmount = children + 1;
                RowAmount = (int)Math.Ceiling(visitors / ChairAmount);
            }
        }

        List<row> newRowList = new();
        for (int i = 0; i < RowAmount; i++)
        {
            List<chair> newChairList = new();
            for (int j = 0; j < ChairAmount; j++)
            {
                chair newChair = new(blockName + rowName + "-" + chairName);
                newChairList.Add(newChair);
                chairName++;
            }
            row newRow = new(newChairList, rowName);
            newRowList.Add(newRow);
            rowName++;
        }
        block newBlock = new(newRowList, blockName.ToString());
        blocklist.Add(newBlock);
    }

    public void PutVisitorsInSeats()
    {
        if (applicationList.Count == 0)
            return;

        char blockName = 'A';
        char blockName2 = 'A';
        char blockName3 = 'A';


        foreach (reservation reservation in applicationList)
        {
            double groupCount = reservation.group.personlist.Count;
            int childrenAmount = reservation.group.GetChildrenAmount();
            string name = "";
            name += blockName;
            
            if (blockName != 'Z')
                blockName++;
            else if (blockName2 != 'Z')
            {
                name += blockName2;
                blockName2++;
            }
            else if (blockName3 != 'Z')
            {
                name += blockName2 + blockName3;
                blockName3++;
            }

            MakeBlock(childrenAmount, groupCount, name);

            reservation.group.personlist.OrderByDescending(n => n.adult);
            for (int i = 0; i < reservation.group.personlist.Count - 1; i++)
            {
                double j = i;
                int blockIndex = blocklist.Count - 1;
                int rowIndex = (int)Math.Floor(j / blocklist[0].rowlist[0].chairlist.Count);
                int seatIndex = i % blocklist[0].rowlist[0].chairlist.Count;
                reservation.group.personlist[i].assignedSeat = blocklist[blockIndex].rowlist[rowIndex].chairlist[seatIndex];
            }
        }
    }
}
