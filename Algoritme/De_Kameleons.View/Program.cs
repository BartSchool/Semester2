namespace De_Kameleons.View;
internal class Program
{
    private static void Main()
    {
        Util util = new Util();
        Console.OutputEncoding = System.Text.UnicodeEncoding.UTF8;
        Console.BackgroundColor = ConsoleColor.White;
        bool changed = true;
        string text = "Welcome to the internet";
        while (true)
        {
            if (changed)
                util.WriteKameleonsInEnclosure(new De_Kameleions.Core.Kameleon(ConsoleColor.Gray), new De_Kameleions.Core.Kameleon(ConsoleColor.Black));
            Thread.Sleep(1000);

            changed = false;
        }
    }
}