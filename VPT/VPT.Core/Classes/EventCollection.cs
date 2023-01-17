using VPT.Core.Dto_s;
using VPT.Core.Interfaces;

namespace VPT.Core.Classes;

public class EventCollection
{
    public List<Event> EventList { get; private set; }
	private IEventCollection? _events;

	public EventCollection(IEventCollection _events)
	{
		this._events = _events;
		this.EventList = GetEvents();
	}

	public EventCollection(List<Event> eventList)
	{
		EventList = eventList;
	}

	public void addEvent(DtoEvent Event)
	{
		if (_events != null)
			_events.AddEvent(Event);
		EventList = GetEvents();
	}

	public void addEvents(List<DtoEvent> Events)
	{
        if (_events != null)
            foreach (DtoEvent Event in Events)
				_events.AddEvent(Event);
        EventList = GetEvents();
    }

	public void removeEvent(DtoEvent Event)
	{
		if (_events != null)
			_events.RemoveEvent(Event);
        EventList = GetEvents();
    }

	private List<Event> GetEvents()
	{
		List<Event> list = new List<Event>();
		if (_events != null)
			foreach (DtoEvent checkedEvent in _events.EventList)
				list.Add(new(checkedEvent));
		return list;
	}
}
