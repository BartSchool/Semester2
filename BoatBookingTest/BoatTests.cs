using BoatBookingCore;
using BoatBookingMock;

namespace BoatBookingTest;

public class BoatTests
{
    [Fact]
    public void WeCanCreateBoatsObjectWithBoatList()
    {
        Boats boats = new(new MockDb());
        Assert.NotNull(boats);
        Assert.NotNull(boats.BoatList);
    }

    [Fact]
    public void CanWeAddBoat()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");

        Assert.Single(boats.BoatList);
    }

    [Fact]
    public void DoesItReturnFalseWhenITryToInputAWrongCertificate()
    {
        Users users = new(new MockDb());

        Assert.False(users.AreCertificatesRight("sk6"));
    }

    [Fact]
    public void DoesItReturnTrueWhenITryToInputARightCertificate()
    {
        Users users = new(new MockDb());

        Assert.True(users.AreCertificatesRight("sk1"));
    }

    [Fact]
    public void DoesItReturnTrueIfBoatAllreadyExists()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");

        Assert.True(boats.doesBoatExist("bob"));
    }

    [Fact]
    public void BoatCheckIsCaseSensative()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");

        Assert.False(boats.doesBoatExist("Bob"));
    }

    [Fact]
    public void CanWeRemoveABoat()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");
        boats.AddBoat("bobby", "c4+", null, null, "");

        boats.RemoveBoat("bob","c4+");

        Assert.Single(boats.BoatList);
    }

    [Fact]
    public void CantCreateABoatWithANameWithALengthOf0()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");
        Assert.Throws<ArgumentOutOfRangeException>(() => boats.AddBoat("", "c4+", null, null, ""));
    }

    [Fact]
    public void CantCreateABoatWithATypeWithALengthOf0()
    {
        Boats boats = new(new MockDb());
        boats.AddBoat("bob", "c4+", null, null, "");
        Assert.Throws<ArgumentOutOfRangeException>(() => boats.AddBoat("bobby", "", null, null, ""));
    }
}
