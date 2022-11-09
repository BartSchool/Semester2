namespace Circustrein.test
{
    public class CoreTests
    {
        Train train = new Train();
        List<Animal> animals = new List<Animal>();

        

        [Fact]
        public void Senario1()
        {
            Core core = new Core();

            core.addAnimals(1, 0, 0, 0, 3, 2);
            core.SolveTrain();

            Assert.Equal(2, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario2()
        {
            Core core = new Core();

            core.addAnimals(1, 0, 0, 5, 2, 1);
            core.SolveTrain();

            Assert.Equal(2, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario3()
        {
            Core core = new Core();

            core.addAnimals(1, 1, 1, 1, 1, 1);
            core.SolveTrain();

            Assert.Equal(4, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario4()
        {
            Core core = new Core();

            core.addAnimals(2, 1, 1, 1, 5, 1);
            core.SolveTrain();

            Assert.Equal(5, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario5()
        {
            Core core = new Core();

            core.addAnimals(1, 0, 0, 1, 1, 2);
            core.SolveTrain();

            Assert.Equal(2, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario6()
        {
            Core core = new Core();

            core.addAnimals(3, 0, 0, 0, 2, 3);
            core.SolveTrain();

            Assert.Equal(3, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario7()
        {
            Core core = new Core();

            core.addAnimals(7, 3, 3, 0, 5, 6);
            core.SolveTrain();

            Assert.Equal(13, core.train.GetCarts().Count);
        }

        [Fact]
        public void Senario8()
        {
            Core core = new Core();

            core.addAnimals(0, 0, 0, 0, 0, 0);
            core.SolveTrain();

            Assert.Equal(0, core.train.GetCarts().Count);
        }
    }
}