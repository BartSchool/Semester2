using VPT.Core.Classes;

namespace VPT.Core.Dto_s;

public class DtoGroup
{
    public List<DtoPerson> personlist { get; private set; }
    public int code { get; private set; }

    public DtoGroup(group dto)
    {
        personlist = new();
        foreach (person person in dto.personlist)
            personlist.Add(new(person));
        code = dto.code;
    }

    public DtoGroup(int code)
    {
        this.code = code;
        this.personlist = new();
    }

    public DtoGroup(List<DtoPerson> personlist, int code) : this(code)
    {
        this.personlist = personlist;
    }
}
