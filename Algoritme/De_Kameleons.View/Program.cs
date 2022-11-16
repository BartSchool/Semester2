using De_Kameleions.Core;
using System.Runtime.CompilerServices;

namespace De_Kameleons.View;
internal class Program
{
    private static void Main()
    {
        Util util = new Util();
        Console.OutputEncoding = System.Text.UnicodeEncoding.UTF8;
        Console.BackgroundColor = ConsoleColor.White;

        Enclosure enclosure = new Enclosure();
        enclosure.SetStartingKameleons();

        while (!enclosure.isDone)
        {
            util.showEncounter(enclosure);
        }

        util.finishingScreen(enclosure);
    }
}