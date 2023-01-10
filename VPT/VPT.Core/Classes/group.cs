namespace VPT.Core.Classes;

public class group
{
    public List<person> personlist { get; private set; }
    public int code { get; private set; }

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
}
