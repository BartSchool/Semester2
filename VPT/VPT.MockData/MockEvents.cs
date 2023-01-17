using VPT.Core.Dto_s;
using VPT.Core.Interfaces;

namespace VPT.MockData;

public class MockEvents : IEventCollection
{
    public List<DtoEvent> EventList { get; set; }

    public MockEvents()
    {
        EventList = new List<DtoEvent>();
    }

    public void AddEvent(DtoEvent @event)
    {
        EventList.Add(@event);
    }

    public void RemoveEvent(DtoEvent @event)
    {
        foreach (var item in EventList)
            if (item.name == @event.name)
                EventList.Remove(item);
    }
}