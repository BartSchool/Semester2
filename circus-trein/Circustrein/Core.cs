namespace Circustrein
{
    public class Core
    {

        public Train train = new Train();
        private int cartSize = 10;
        private List<Animal> animals = new List<Animal>();
        private int ST1 = 10;
        private int ST2 = 500;

        public void Main()
        {
            WriteText("Welcome to the Circus train solver!");
            WriteText("Now lets get all the information on the animals youre moving.");

            AskAllAnimals();
            SolveTrain();
            ShowTrain();
        }

        public void addAnimals(int sc, int ac, int bc, int sh, int ah, int bh)
        {
            for (int i = 0; i < sc; i++)
                animals.Add(new Animal("small", "", "c"));
            for (int i = 0; i < ac; i++)
                animals.Add(new Animal("avarage", "", "c"));
            for (int i = 0; i < bc; i++)
                animals.Add(new Animal("big", "", "c"));

            for (int i = 0; i < sh; i++)
                animals.Add(new Animal("small", "", "h"));
            for (int i = 0; i < ah; i++)
                animals.Add(new Animal("avarage", "", "h"));
            for (int i = 0; i < bh; i++)
                animals.Add(new Animal("big", "", "h"));
        }

        private void WriteText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(ST1);
            }
            Thread.Sleep(ST2);
            Console.WriteLine();
        }
        private string WriteQuestion(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(ST1/2);
            }
            Console.Write(" ");
            return Console.ReadLine();
        }

        private void AskAnimal()
        {
            string name;
            string dieet;
            string size;
            name = WriteQuestion("Name:");
            dieet = WriteQuestion("Diet:");
            size = WriteQuestion("Size:");
            animals.Add(new Animal(size, name, dieet));
        }
        private void AskAllAnimals()
        {
            WriteText("Before I let you fill in all the information on all your animals... \nLet me make sure you know how to...");
            WriteText("I will show you all the questions you will get asked for all your animals.\n Together with the accepted answers...");
            WriteText("Name: [Anything goes here, iam not gonna judge the names you give your animals]");
            WriteText("Diet: [h/c] you can choose between herbivore and carnivore,\n omnivores also eat animals so you can put them as a carnivore");
            WriteText("Size: [small/avarage/big] you can dicide yourself whats small or big...\n if it doest fit in the train thats your bad :)...");
            WriteText("Were these all your animals [y/n] \nif you press y the program will calculate the least amount of carts you need to rent for all the animals");
            Console.WriteLine();
            WriteText("okay with that out of the way... \nLets get started with the first animal.");

            bool done = false;
            int count = 0;
            while (!done)
            {
                count++;
                WriteText("animal " + count.ToString());
                AskAnimal();
                if (WriteQuestion("Were these all your animals?") == "y")
                {
                    done = true;
                }
            }
        }
        private void AddToCart(Cart cart ,int i)
        {
            cart.AddAnimal(animals[i]);
            animals.RemoveAt(i);
        }
        public void SolveTrain()
        {
            int id = 0;
            Cart cart = new Cart(cartSize);
            SortList();
            if (animals.Count() == 0)
                return;
            while (animals.Count() > 0)
            {
                bool succes = false;
                int i = 0;
                int bigAnimal = 0;
                int smallAnimal = 10;
                int smallCarnivore = 10;

                if (cart.getSpace() == 0 || cart.GetCarnivoreSize() == 5)
                {
                    train.AddCart(cart);
                    id++;
                    cart = new Cart(cartSize);
                }
                else if (cart.getSpace() <= cart.GetCarnivoreSize())
                {
                    train.AddCart(cart);
                    id++;
                    cart = new Cart(cartSize);
                }
                else
                {
                    foreach (Animal animal in animals)
                    {
                        int size = animal.GetSizePoints();
                        if (size > bigAnimal)
                            bigAnimal = size;
                        if (animal.GetDieet() == "carnivore" && size < smallCarnivore)
                            smallCarnivore = size;
                        else if (size < smallAnimal)
                            smallAnimal = size;
                    
                    }
                    if (cart.GetCarnivoreSize() >= bigAnimal)
                    {
                        train.AddCart(cart);
                        id++;
                        cart = new Cart(cartSize);
                    }
                    else if (smallAnimal > cart.getSpace())
                    {
                        train.AddCart(cart);
                        id++;
                        cart = new Cart(cartSize);
                    }
                }

                while (!succes && i < animals.Count())
                {
                    Animal animal = animals[i];
                    if (cart.IsSpace(animal))
                    {
                        if (cart.IsCarnivoreOnBoard())
                        {
                            if (smallAnimal != 1 && cart.GetCarnivoreSize() == 1 && cart.getSpace()%3 == 0 && animal.GetSizePoints() != 3)
                            {
                                bool isAvarage = false;
                                foreach (Animal animol in animals)
                                    if (animol.GetSizePoints() == 3)
                                        isAvarage = true;

                                if (!isAvarage)
                                    if (cart.GetCarnivoreSize() < animal.GetSizePoints())
                                        if (animal.GetDieet() == "herbivore")
                                        {
                                            AddToCart(cart, i);
                                            succes = true;
                                        }
                            }
                            else if (cart.GetCarnivoreSize() < animal.GetSizePoints())
                                if (animal.GetDieet() == "herbivore")
                                {
                                    AddToCart(cart, i);
                                    succes = true;
                                }
                        }
                        else
                        {
                            if (animal.GetDieet() == "carnivore")
                            {
                                bool tooBig = false;
                                int j = 0;
                                while (!tooBig && j < cart.GetAnimals().Count)
                                {
                                    if (cart.GetAnimals()[j].GetSizePoints() <= animal.GetSizePoints())
                                        tooBig = true;
                                    j++;
                                }
                                if (!tooBig)
                                {
                                    cart.SetCarnivoreOnBoard(true);
                                    cart.SetCarnivoreSize(animal.GetSizePoints());
                                    AddToCart(cart, i);
                                    succes = true;
                                }
                            }
                            else
                            {
                                AddToCart(cart, i);
                                succes = true;
                            }
                        }
                    }
                    i++;
                }
            }
            train.AddCart(cart);
        }
        private void ShowTrain()
        {
            WriteText("This is the train:");
            int id = 0;
            foreach (Cart cart in train.GetCarts())
            {
                id++;
                Console.Write("Cart: "+ id.ToString() +" "+ cart.getSpace() +"\n"+
                    "------------------------\n");
                foreach (Animal animal in cart.GetAnimals())
                {
                    Console.WriteLine("| " + animal.GetName() + " | " + animal.GetSizePoints() + " | " + animal.GetDieet() + " |");
                }
                Console.WriteLine("------------------------");
            }
        }
        private void SortList()
        {
            animals.Sort((x, y) => y.GetSizePoints().CompareTo(x.GetSizePoints()));
            animals = animals.OrderBy(o => o.GetDieet()).ToList();
        }
    }
}