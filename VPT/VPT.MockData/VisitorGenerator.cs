using VPT.Core.Dto_s;

namespace VPT.MockData;

public class VisitorGenerator
{
    private static readonly Random rnd = new Random();

    public VisitorGenerator()
    {

    }

    private DtoPerson GetRandomPerson()
    {
        int newRnd = rnd.Next(4, 90);

        string newName = "person" + newRnd;
        DateOnly newDate = DateOnly.FromDateTime(DateTime.Now.Add(new TimeSpan(-newRnd*370, 0,0,0)));
        return new(newName, newDate);
    }

    private DtoPerson GetRandomChild()
    {
        int newRnd = rnd.Next(4, 11);

        string newName = "child" + newRnd;
        DateOnly newDate = DateOnly.FromDateTime(DateTime.Now.Add(new TimeSpan(-newRnd * 370, 0, 0, 0)));
        return new(newName, newDate);
    }

    private DtoPerson GetRandomAdult()
    {
        int newRnd = rnd.Next(12, 90);

        string newName = "adult" + newRnd;
        DateOnly newDate = DateOnly.FromDateTime(DateTime.Now.Add(new TimeSpan(-newRnd * 370, 0, 0, 0)));
        return new(newName, newDate);
    }

    private List<DtoPerson> GetRandomPersons(int amount)
    {
        List<DtoPerson> persons = new List<DtoPerson>();
        for (int i = 0; i < amount; i++)
            persons.Add(GetRandomPerson());
        return persons;
    }

    private List<DtoPerson> GetRandomChildren(int amount)
    {
        List<DtoPerson> persons = new List<DtoPerson>();
        for (int i = 0; i < amount; i++)
            persons.Add(GetRandomChild());
        return persons;
    }

    private List<DtoPerson> GetRandomAdults(int amount)
    {
        List<DtoPerson> persons = new List<DtoPerson>();
        for (int i = 0; i < amount; i++)
            persons.Add(GetRandomAdult());
        return persons;
    }

    public List<DtoPerson> GetRandomVisitors(int random, int adults, int child)
    {
        List<DtoPerson> list = new();
        list.AddRange(GetRandomPersons(random));
        list.AddRange(GetRandomAdults(adults));
        list.AddRange(GetRandomChildren(child));
        return list;
    }
}
