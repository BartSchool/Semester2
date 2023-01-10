namespace VPT.Core.Classes;

public class Event
{
    public DateTime lastRegisterTime { get; private set; }
    public DateTime eventStart { get; private set; }
    public int spaceses { get; private set; }
    public List<block> blocklist { get; private set; }
    public List<application> applicationList { get; private set; }

    public Event(DateTime lastRegisterTime, DateTime eventStart, int spaceses, List<block> blocklist, List<application> applicationList)
    {
        this.lastRegisterTime = lastRegisterTime;
        this.eventStart = eventStart;
        this.spaceses = spaceses;
        this.blocklist = blocklist;
        this.applicationList = applicationList;
    }

    public void addBlock(block block)
    {
        blocklist.Add(block);
    }

    public void removeBlock(block block)
    {
        foreach (block checkedblock in blocklist)
            if (checkedblock == block)
            {
                blocklist.Remove(checkedblock);
                break;
            }
    }
}
