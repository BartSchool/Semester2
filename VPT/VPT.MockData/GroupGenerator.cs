using VPT.Core.Classes;
using VPT.Core.Dto_s;

namespace VPT.MockData;

public class GroupGenerator
{
    private static readonly Random rnd = new Random();
	private static readonly VisitorGenerator _visitors = new();

	public GroupGenerator()
	{

	}

	public DtoGroup GetRandomGroup()
	{
		int NextRnd = rnd.Next(0, 29);

		List<DtoPerson> persons = new List<DtoPerson>();
		persons.AddRange(_visitors.GetRandomVisitors(NextRnd,1,0));
		int code = 0;
		foreach (DtoPerson person in persons)
			code += person.birthDate.Year;

		return new(persons, code);
	}

	public DtoGroup GetGroup(int adults, int children)
	{
		List<DtoPerson> persons = new List<DtoPerson>();
		persons.AddRange(_visitors.GetRandomVisitors(0, adults, children));
        int code = 0;
        foreach (DtoPerson person in persons)
            code += person.birthDate.Year;
		return new(persons, code);
    }

	public List<DtoGroup> GetRandomGroups(int amount)
	{
		List<DtoGroup> list = new();
		for (int i = 0; i < amount; i++)
			list.Add(GetRandomGroup());
		return list;
	}
}
