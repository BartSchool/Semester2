namespace Puzzles
{
    internal class Order
    {
        private List<Product> products;
        
        public Order()
        {
            products = new List<Product>();
        }

        public void AddProduct(string name, double price)
        {
            products.Add(new Product(name, price));
        }

        public Product GiveMaximumPrice()
        {
            Product max = new Product("max", 0);
            foreach (Product p in products)
                if (p.getPrice() > max.getPrice())
                    max = p;

            return max;
        }

        public double GiveTotalPrice()
        {
            double total = 0;
            foreach (Product p in products)
                total += p.getPrice();

            return total;
        }

        public double GiveAvaragePrice()
        {
            return GiveTotalPrice()/products.Count();
        }

        public List<Product> GetAllProducts(double minimumPrice)
        {
            List<Product> productsUnder = new List<Product>();
            foreach (Product p in products)
                if (p.getPrice() < minimumPrice)
                    productsUnder.Add(p);

            return productsUnder;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void SortProductsByPrice()
        {
            List<Product> sortedList = new List<Product>();
            foreach(Product p in products)
                if (sortedList.Count == 0)
                    sortedList.Add(p);
                else
                {
                    bool added = false;
                    for (int i = 0; i < sortedList.Count; i++)
                    {
                        if (p.getPrice() > sortedList[i].getPrice())
                        {
                            sortedList.Insert(i, p);
                            added = true;
                            break;
                        }
                    }
                    if (!added)
                        sortedList.Add(p);
                }



            products = sortedList;
        }
    }
}
