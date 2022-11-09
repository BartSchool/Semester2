namespace Circustrein.test
{
    public class TrainTests
    {
        [Fact]
        public void TrainCanBeMade()
        {
            Train train = new Train();

            Assert.NotNull(train);
        }

        [Fact]
        public void CanWeAddACartToTheTrainAndGetTheCartsFromTheTrain()
        {
            Train train = new Train();

            train.AddCart(new Cart());

            Assert.NotEmpty(train.GetCarts());
        }

        [Fact]
        public void CanWeGet3CartsFromTheTrain()
        {
            Train train = new Train();
            train.AddCart(new Cart());
            train.AddCart(new Cart());
            train.AddCart(new Cart());

            Assert.Equal(3, train.GetCarts().Count);
        }
    }
}