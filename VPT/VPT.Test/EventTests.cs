using VPT.Core.Classes;
using VPT.Core.Dto_s;
using VPT.MockData;

namespace VPT.Test;

public class EventTests
{
    private EventCollection events = new(new MockEvents());
    private EventGenerator eventGenerator = new();
    private reservationGenerator reservationGenerator = new();

    [Fact]
    public void CanWeCreateEventCollection()
    {
        Assert.NotNull(eventGenerator);
        Assert.NotNull(events);
    }

    [Fact]
    public void CanWeAddEvent()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());
        Assert.NotEmpty(events.EventList);
    }

    [Fact]
    public void CanWeAddApplicationToEvent()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());

        events.EventList[0].AddReservation(reservationGenerator.makeReservationWithRandomPeople(new(events.EventList[0])));

        Assert.NotEmpty(events.EventList[0].applicationList);
    }

    [Fact]
    public void CantAddLateApplications()
    {
        events.addEvents(eventGenerator.GiveRandomEvents(2));

        Action act = () => events.EventList[0].AddReservation(reservationGenerator.makeLateReservation(new(events.EventList[0])));

        Assert.Throws<Exception>(act);
    }

    [Fact]
    public void DoesAgeAtEventGetCalculated()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());

        events.EventList[0].AddReservation(reservationGenerator.makeReservation(new(events.EventList[0]), 1, 1));

        Assert.True(events.EventList[0].applicationList[0].group.personlist[0].adult);
        Assert.False(events.EventList[0].applicationList[0].group.personlist[1].adult);
    }

    [Fact]
    public void CantAddGroupWithOnlyChildren()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());

        Action  act = () => events.EventList[0].AddReservation(reservationGenerator.makeReservation(new(events.EventList[0]), 0, 10));

        Assert.Throws<Exception>(act);
    }

    [Fact]
    public void CanPlaceVisitorsInSeats()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());
        events.EventList[0].AddReservations(reservationGenerator.makeReservationsWithRandomPeople(10 , new(events.EventList[0])));

        events.EventList[0].PutVisitorsInSeats();

        Assert.NotNull(events.EventList[0].applicationList[0].group.personlist[0].assignedSeat);
    }

    [Fact]
    public void putsChildrenInFirstSeats()
    {
        events.addEvent(eventGenerator.GiveRandomEvent());
        events.EventList[0].AddReservations(reservationGenerator.makeReservationsWithRandomPeople(1, new(events.EventList[0])));

        events.EventList[0].PutVisitorsInSeats();

        foreach (person person in events.EventList[0].applicationList[0].group.personlist)
        {
            if (person.adult == false)
            {
                Assert.Equal(0, getFirstDigit(person.assignedSeat.code));
            }
        }
    }

    private int getFirstDigit(string test)
    {
        foreach (char c in test)
        {
            if (Char.IsDigit(c))
            {
                return c;
            }
        }
        throw new Exception("No digits");
    }
}