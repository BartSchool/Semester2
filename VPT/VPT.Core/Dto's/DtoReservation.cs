using VPT.Core.Classes;

namespace VPT.Core.Dto_s;

public class DtoReservation
{
    public DtoGroup group { get; private set; }
    public DateTime time { get; private set; }
    public DtoEvent Event { get; private set; }

    public DtoReservation(DtoGroup group, DateTime time, DtoEvent @event)
    {
        this.group = group;
        this.time = time;
        Event = @event;
    }
}
