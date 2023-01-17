using System.Net.Http.Headers;
using VPT.Core.Dto_s;

namespace VPT.Core.Classes;

public class reservation
{
    public group? group { get; private set; }
    public DateTime time { get; private set; }
    public Event Event { get; private set; }

    public reservation(DtoReservation dto)
    {
        group = new(dto.group);
        time = dto.time;
        Event = new(dto.Event);

        CalculatePersonEventAge(this.group);
        if (!IsGroupValid(this.group))
            throw new Exception("group is invalid");
    }

    public reservation(group group, DateTime time, Event @event)
    {
        this.group = group;
        this.time = time;
        Event = @event;

        CalculatePersonEventAge(this.group);
        if (!IsGroupValid(this.group))
            throw new Exception("group is invalid");
    }

    private void CalculatePersonEventAge(group group)
    {
        foreach (person person in group.personlist)
            person.GetAgeAtEvent(Event.eventStart);
    }

    private bool IsGroupValid(group group)
    {
        int adults = 0;
        int children = 0;

        foreach (person person in group.personlist)
        {
            if (person.adult == true)
                adults++;
            else if (person.adult == false)
                children++;
        }

        if (children > 0 && adults <= 0)
            throw new Exception("reservation, cant have child without adult");
        return true;
    }
}
