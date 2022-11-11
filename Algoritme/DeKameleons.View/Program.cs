
namespace DeKameleons.View
{
    public static class Program
    {
        public static void Main()
        {
            String Enclosure =
                "┌——————————————————————————————————————┐\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "│" + ""                             + "│\n" +
                "└――――――――――――――――――――――――――――――――――――――┘\n";
                //"-01234567890123456780123456789012345678-

            Console.WriteLine("Kameleon :)");

            while (true)
            {
                Console.WriteLine(Enclosure);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}