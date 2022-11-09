namespace Puzzles
{
    internal class Product
    {
        private string Name;
        private double Price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double getPrice()
        {
            return Price;
        }

        public string getName()
        {
            return Name;
        }
    }
}
