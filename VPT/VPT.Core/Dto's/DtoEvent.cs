using VPT.Core.Classes;

namespace VPT.Core.Dto_s;

public class DtoEvent
{
    private static readonly Random rnd = new Random();

    public string name { get; private set; }
    public DateTime lastRegisterTime { get; private set; }
    public DateTime eventStart { get; private set; }
    public int spaces { get; private set; }
    public List<block> blocklist { get; private set; }
    public List<reservation> applicationList { get; private set; }

    public DtoEvent(Event @event)
    {
        name = @event.name;
        lastRegisterTime = @event.lastRegisterTime;
        eventStart = @event.eventStart;
        spaces = @event.spaces;
        blocklist = @event.blocklist;
        applicationList = @event.applicationList;
    }

    public DtoEvent(DateTime lastRegisterTime, DateTime eventStart, int spaces, string name)
    {
        this.lastRegisterTime = lastRegisterTime;
        this.eventStart = eventStart;
        this.spaces = spaces;
        this.blocklist = new();
        this.applicationList = new();
        this.name = name;
    }

    public DtoEvent(string name, DateTime lastRegisterTime, DateTime eventStart, int spaces, List<block> blocklist, List<reservation> applicationList) : this(lastRegisterTime, eventStart, spaces, name)
    {
        this.blocklist = blocklist;
        this.applicationList = applicationList;
    }
}
