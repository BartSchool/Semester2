namespace VPT.Core.Classes;

public class application
{
    public group group { get; private set; }
    public DateTime time { get; private set; }
    public Event Event { get; private set; }

    public application(group group, DateTime time, Event @event)
    {
        this.group = group;
        this.time = time;
        Event = @event;
    }
}
