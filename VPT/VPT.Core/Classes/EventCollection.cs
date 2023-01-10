namespace VPT.Core.Classes;

public class EventCollection
{
    public List<Event> EventList { get; private set; }

	public EventCollection(List<Event> eventList)
	{
		EventList = eventList;
	}

	public void addEvent(Event Event)
	{
		EventList.Add(Event);
	}

	public void removeEvent(Event Event)
	{
		foreach (Event checkedEvent in EventList)
			if (checkedEvent == Event) 
			{
				EventList.Remove(checkedEvent);
				break;
			}
	}
}
