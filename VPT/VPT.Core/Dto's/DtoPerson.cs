using VPT.Core.Classes;

namespace VPT.Core.Dto_s;

public class DtoPerson
{
    public bool? adult { get; private set; }
    public int? ageAtEvent { get; private set; }
    public string name { get; private set; }
    public DateOnly birthDate { get; private set; }
    private DateOnly Today = DateOnly.FromDateTime(DateTime.Now);

    public DtoPerson(person dto)
    {
        adult = dto.adult;
        ageAtEvent = dto.ageAtEvent;
        name = dto.name;
        birthDate = dto.birthDate;
    }

    public DtoPerson(string name, DateOnly BirthDate)
    {
        this.name = name;
        birthDate = BirthDate;
        ageAtEvent = null;
        adult = null;
    }
}
