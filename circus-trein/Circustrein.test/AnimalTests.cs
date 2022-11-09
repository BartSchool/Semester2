namespace Circustrein.test
{
    public class AnimalTests
    {
        [Fact]
        public void AnimalCanBeMade()
        {
            Animal animal = new Animal("big","bob","h");

            Assert.NotNull(animal);
        }

        [Fact]
        public void CanGetRightNameFromAnimal()
        {
            Animal animal1 = new Animal("big", "bob", "h");
            Animal animal2 = new Animal("big", "bart", "h");

            Assert.Equal("bob", animal1.GetName());
            Assert.Equal("bart", animal2.GetName());
        }

        [Fact]
        public void DoesSizeMatchSizzePoints()
        {
            Animal animal1 = new Animal("small", "bob", "h");
            Animal animal2 = new Animal("avarage", "bob", "h");
            Animal animal3 = new Animal("big", "bob", "h");

            Assert.Equal("small", animal1.GetSize());
            Assert.Equal(1, animal1.GetSizePoints());

            Assert.Equal("avarage", animal2.GetSize());
            Assert.Equal(3, animal2.GetSizePoints());

            Assert.Equal("big", animal3.GetSize());
            Assert.Equal(5, animal3.GetSizePoints());
        }

        [Fact]
        public void CanGetCorrectDietFromAnimal()
        {
            Animal animal1 = new Animal("big", "bob", "h");
            Animal animal2 = new Animal("big", "bob", "c");

            Assert.Equal("herbivore", animal1.GetDieet());
            Assert.Equal("carnivore", animal2.GetDieet());
        }
    }
}