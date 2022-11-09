using Puzzles;

Order order = new Order();
Console.WriteLine("Welcome customer");

keuzeMenu();

void keuzeMenu()
{
    bool gotValidAnswer = false;

    while (!gotValidAnswer)
    {
        Console.WriteLine("\nwhat would you like to do");
        Console.Write("[1] add products" +
            "\n[2] get the most expensive item in my order" +
            "\n[3] get the average price of my order" +
            "\n[4] get all products in my order" +
            "\n[5] sort my order by price" +
            "\n[6] close app" +
            "\nPlease write your choice here: ");
        string ans = Console.ReadLine();

        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        switch (int.Parse(ans))
        {
            case 1:
                GetProducts();
                break;
            case 2:
                GetExpensiveItem();
                break;
            case 3:
                GetAvaragePrice();
                break;
            case 4:
                GetAllProducts();
                break;
            case 5:
                OrderProductList();
                break;
            case 6:
                Console.WriteLine("Thank you for using the app");
                gotValidAnswer = true;
                break;
            default:
                Console.WriteLine("please input a valid number");
                break;
        }
        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
}

void GetExpensiveItem()
{
    if (order.GetAllProducts().Count == 0)
    {
        Console.WriteLine("\nthere are no products in your order, please add some products first");
        return;
    }
    Product p = order.GiveMaximumPrice();
    Console.WriteLine($"\nthe most expensive item in your order is:\n| {p.getName()} for ${p.getPrice().ToString()} |");
}

void GetAvaragePrice()
{
    if (order.GetAllProducts().Count == 0)
    {
        Console.WriteLine("\nthere are no products in your order, please add some products first");
        return;
    }
    double average = order.GiveAvaragePrice();
    Console.WriteLine($"\nthe average cost of your products is ${average.ToString()}");
}

void OrderProductList()
{
    order.SortProductsByPrice();
    List<Product> products = order.GetAllProducts();
    Console.WriteLine("this is what your order looks like now");
    foreach (Product product in products)
    {
        Console.WriteLine($"| {product.getName()} ${product.getPrice().ToString()} |");
    }

    Console.WriteLine($"\nFor a total of: ${order.GiveTotalPrice().ToString()}");
}

void GetAllProducts()
{
    List<Product> products;
    Console.Write("\nwhat do you want the minum price of the products to be?\nIf you dont want a minimum value just press enter ");
    string ans = Console.ReadLine();
    if (ans == "")
    {
        products = order.GetAllProducts();
        Console.WriteLine("These are all the products in your order");
    }
    else
    {
        double min = double.Parse(ans);
        products = order.GetAllProducts(min);
        Console.WriteLine($"These are all the products in your order that cost more then ${min}");
    }

    foreach (Product product in products)
    {
        Console.WriteLine($"| {product.getName()} ${product.getPrice().ToString()} |");
    }

    Console.WriteLine($"\nFor a total of: ${order.GiveTotalPrice().ToString()}");
}

void GetProducts() {
    bool addMoreProducts = true;
    double productnumber = order.GetAllProducts().Count() + 1;
    string ans;

    while (addMoreProducts)
    {
        Console.WriteLine($"\nplease provide the information of product #{productnumber.ToString()}");
        Console.Write("name: ");
        string name = Console.ReadLine();
        Console.Write("price: $");
        string price = Console.ReadLine();

        order.AddProduct(name, double.Parse(price));
        productnumber++;

        Console.Write("Do you want to add more products? [y/n] ");
        ans = Console.ReadLine();
        while (ans != "y" && ans != "n")
        {
            Console.WriteLine("please respond with: [y/n] ");
            ans = Console.ReadLine();
        }

        if (ans == "n")
            addMoreProducts = false;
    }
}