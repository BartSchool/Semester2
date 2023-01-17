using VPT.Core.Classes;
using VPT.Core.Dto_s;

namespace VPT.MockData;

public class reservationGenerator
{
    private static readonly Random rnd = new();
    private GroupGenerator groupGenerator = new();

    public reservationGenerator()
	{

	}

    public DtoReservation makeReservationWithRandomPeople(DtoEvent Event)
    {
        DtoGroup group = groupGenerator.GetRandomGroup();
        DateTime time = DateTime.Now;

        return new(group, time, Event);
    }

    public DtoReservation makeReservation(DtoEvent Event, int Adults, int Children)
    {
        DtoGroup group = groupGenerator.GetGroup(Adults, Children);
        DateTime time = DateTime.Now;

        return new(group, time, Event);
    }

    public DtoReservation makeLateReservation(DtoEvent Event)
    {
        DtoGroup group = groupGenerator.GetRandomGroup();
        DateTime time = Event.lastRegisterTime.AddDays(1);

        return new(group, time, Event);
    }

    public List<DtoReservation> makeReservationsWithRandomPeople(int amount, DtoEvent Event)
    {
        List<DtoReservation> list = new();
        for (int i = 0; i < amount; i++)
            list.Add(makeReservationWithRandomPeople(Event));
        return list;
    }
}
