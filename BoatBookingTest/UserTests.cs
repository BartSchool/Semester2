using BoatBookingCore;
using BoatBookingMock;

namespace BoatBookingTest;

public class UserTests
{
    [Fact]
    public void DoWeGetUsers()
    {
        Users users = new(new MockDb());
        Assert.NotNull(users.userList);
    }

    [Fact]
    public void CanWeAddUsers()
    {
        Users users = new(new MockDb());
        users.AddUser("bob", false, "");

        Assert.Single(users.userList);
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
    public void DoesItReturnTrueIfUserAllreadyExists()
    {
        Users users = new(new MockDb());
        users.AddUser("bob", false, "");

        Assert.True(users.DoesUserExist("bob"));
    }

    [Fact]
    public void UsersCheckIsCaseSensative()
    {
        Users users = new(new MockDb());
        users.AddUser("bob", false, "");

        Assert.False(users.DoesUserExist("Bob"));
    }

    [Fact]
    public void CanWeRemoveAUser()
    {
        Users users = new(new MockDb());
        users.AddUser("bob", false, "");
        users.AddUser("billy", false, "");

        users.RemoveUser(new("billy", false, ""));

        Assert.Single(users.userList);
    }

    [Fact]
    public void CantCreateAUsersWithANameWithALengthOf0()
    {
        Users users = new(new MockDb());
        users.AddUser("bob", false, "");
        Assert.Throws<ArgumentOutOfRangeException>(() => users.AddUser("", false, ""));
    }
}
