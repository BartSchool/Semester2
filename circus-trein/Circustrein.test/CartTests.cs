namespace Circustrein.test
{
    public class CartTests
    {
        [Fact]
        public void CanWeCreateACart()
        {
            Cart cart = new Cart();

            Assert.NotNull(cart);
        }

        [Fact]
        public void CanWeCreateACartWithAStandartOf10Spaces()
        {
            Cart cart = new Cart();

            Assert.Equal(10, cart.getSpace());
        }

        [Fact]
        public void CanWeCreateACartWith5Spaces()
        {
            Cart cart = new Cart(5);

            Assert.Equal(5, cart.getSpace());
        }

        [Fact]
        public void IsANewCartEmpty()
        {
            Cart cart = new Cart();

            Assert.Empty(cart.GetAnimals());
        }

        [Fact]
        public void CanAddAnimalOnCart()
        {
            Cart cart = new Cart();
            Animal animal = new Animal("small", "bob", "c");

            cart.AddAnimal(animal);

            Assert.Single(cart.GetAnimals());
        }

        [Fact]
        public void DoesCartContainCarnivoreWhenCarnivoreIsAdded()
        {
            Cart cart = new Cart();

            cart.SetCarnivoreOnBoard(true);

            Assert.True(cart.IsCarnivoreOnBoard());
        }

        [Fact]
        public void IsSpaceReducedWith5WhenBigAnimalIsAdded()
        {
            Cart cart = new Cart();
            Animal animal = new Animal("big", "bob", "c");
            Assert.Equal(10, cart.getSpace());

            cart.AddAnimal(animal);

            Assert.Equal(5, cart.getSpace());
        }

        [Fact]
        public void CartReturnsFalseWhenAnimalDoesntFitInCart()
        {
            Cart cart = new Cart();
            Animal animal = new Animal("big", "bob", "h");

            cart.AddAnimal(animal);
            cart.AddAnimal(animal);

            Assert.False(cart.IsSpace(animal));
        }

        [Fact]
        public void CartReturnsTrueWhenAnimalDoesFitInCart()
        {
            Cart cart = new Cart();
            Animal animal = new Animal("big", "bob", "h");

            cart.AddAnimal(animal);

            Assert.True(cart.IsSpace(animal));
        }
    }
}
