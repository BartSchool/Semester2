using VPT.Core.Dto_s;

namespace VPT.MockData;

public class EventGenerator
{
    public List<DtoEvent> EventList { get; set; }
    private static readonly Random rnd = new Random();

    public EventGenerator()
    {
        EventList = new();
    }

    public DtoEvent GiveRandomEvent()
    {
        DateTime now = DateTime.Now;
        int newRandom = rnd.Next(60, 100);

        string name = "event" + newRandom;
        int spaces = newRandom * 300;
        DateTime start = now.AddDays(newRandom);
        DateTime end = now.AddDays(newRandom-59);
        DtoEvent newEvent = new(end, start, spaces, name);
        return newEvent;
    }

    public List<DtoEvent> GiveRandomEvents(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            DateTime now = DateTime.Now;
            int newRandom = rnd.Next(60, 100);

            string name = "event" + newRandom;
            int spaces = newRandom * 300;
            DateTime start = now.AddDays(newRandom);
            DateTime end = now.AddDays(newRandom - 59);
            DtoEvent newEvent = new(end, start, spaces, name);
            EventList.Add(newEvent);
        }

        return EventList;
    }
}