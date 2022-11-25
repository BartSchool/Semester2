using BoatBookingCore;
using BoatBookingMock;

namespace BoatBookingTest
{
    public class UserTests
    {
        [Fact]
        public void DoWeGetUsers()
        {
            Users users = new Users(new MockDb());
            
            Assert.NotNull(users.userList);
        }

        [Fact]
        public void CanWeAddUsers()
        {
            Users users = new Users(new MockDb());
            users.AddUser("bob", false, "");

            Assert.Single(users.userList);
        }
    }
}
