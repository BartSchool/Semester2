using VPT.Core.Dto_s;

namespace VPT.Core.Classes;

public class group
{
    public List<person> personlist { get; private set; }
    public int code { get; private set; }

    public group(DtoGroup dto)
    {
        personlist = new();
        foreach (DtoPerson person in dto.personlist)
            personlist.Add(new(person));
        code = dto.code;
    }

    public group(List<person> personlist, int code)
    {
        this.personlist = personlist;
        this.code = code;
    }

    public void addperson(person person)
    {
        personlist.Add(person);
    }

    public void removeperson(person person)
    {
        foreach (person checkedperson in personlist)
            if (checkedperson == person)
            {
                personlist.Remove(checkedperson);
                break;
            }
    }

    public int GetChildrenAmount()
    {
        int amount = 0;
        foreach (person person in personlist)
            if (person.adult == false)
                amount++;
        return amount;
    }

    public int GetAdultAmount()
    {
        int amount = 0;
        foreach (person person in personlist)
            if (person.adult == true)
                amount++;
        return amount;
    }
}
