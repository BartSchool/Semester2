using System.Dynamic;
using VPT.Core.Dto_s;

namespace VPT.Core.Classes;

public class person
{
    public bool? adult { get; private set; }
    public int? ageAtEvent { get; private set; }
    public string name { get; private set; }
    public DateOnly birthDate { get; private set; }
    public chair? assignedSeat { get; set; }
    private DateOnly Today = DateOnly.FromDateTime(DateTime.Now);

    public person(DtoPerson dto)
    {
        adult = dto.adult;
        ageAtEvent = dto.ageAtEvent;
        name = dto.name;
        birthDate = dto.birthDate;
    }

    public person(string name,  DateOnly birthDate)
    {
        this.ageAtEvent = null;
        this.name = name;
        this.birthDate = birthDate;
        this.adult = null;
    }

    public void GetAgeAtEvent(DateTime startOfEvent)
    {
        ageAtEvent = startOfEvent.Year - birthDate.Year;
        adult = true;
        if (ageAtEvent < 13)
            adult = false;
    }
}
