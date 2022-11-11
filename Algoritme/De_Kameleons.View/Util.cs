using De_Kameleions.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Kameleons.View
{
    internal class Util
    {
        private string s1 = " ╱▉▔▉▔▉▔▉╲▕▔╲      ";
        private string s2 = "╱▕▋▕▋▕▋▕▋ ▔ ╰╲     ";
        private string s3 = "▏▕▎▕▎▕▎▕▎ ▕▔╲╰╲    ";
        private string s4 = "▏╱▔▔╲▂  ▂▂▏╲▇▏▕    ";
        private string s5 = "▏▏╱╲▕ ╲╰╲ ╲╰━━━━╮  ";
        private string s6 = "╲╲▏╱▕  ╲╰▔▏▔▔▔ ╰╯  ";
        private string s7 = " ╲▂▂╱   ▔▔         ";

        private string s11 = "      ╱▔▏╱█▔█▔█▔█╲ ";
        private string s12 = "     ╱╯ ▔ ▐ ▐ ▐ ▐ ╲";
        private string s13 = "    ╱╯╱▔▏  ▎▕▎▕▎▕▎▕";
        private string s14 = "    ▏▕▇╱▕▂▂  ▂╱▔▔╲▕";
        private string s15 = "  ╭━━━━╯╱ ╱╯╱ ▏╱╲▕▕";
        private string s16 = "  ╰╯ ▔▔▔▕▔╯╱  ▏╲▕╱╱";
        private string s17 = "         ▔▔   ╲▂▂╱ ";

        public void writeTextInDeMidden(string s)
        {
            Console.Clear();
            writeEmptySpaces(14);
            writeMiddle(s);
        }

        private void writeEmptySpaces(int j)
        {
            for (int i = 0; i < j; i++)
                Console.WriteLine();
        }

        private void writeMiddle(string s)
        {
            int Max = 120;
            int empty = Max - s.Length;

            writeEmptyTabs(empty / 2);
            Console.Write(s);
        }

        private void writeEmptyTabs(int j)
        {
            for (int i = 0; i < j; i++)
                Console.Write(" ");
        }

        private void CK(Kameleon k)
        {
            Console.ForegroundColor = k.GetColor();
        }

        private void CB()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        private void W(string s)
        {
            Console.Write(s);
        }

        private static string R(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public void WriteKameleonsInEnclosure(Kameleon k1, Kameleon k2)
        {
            Console.Clear();
            writeEmptySpaces(10);
            //                                       ◀━━━━━━━━━━━━━━━━━━40━━━━━━━━━━━━━━━━━━▶
            writeEmptyTabs((120 - 40) / 2); CB(); W("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n");  // ▲
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s1);CK(k2);W(s11);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s2);CK(k2);W(s12);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s3);CK(k2);W(s13);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s4);CK(k2);W(s14);CB();W(" ┃\n");  // 9
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s5);CK(k2);W(s15);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s6);CK(k2);W(s16);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┃ ");CK(k1);W(s7);CK(k2);W(s17);CB();W(" ┃\n");  // ┃
            writeEmptyTabs((120 - 40) / 2); CB(); W("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n");  // ▼

            writeEmptySpaces(2);
            W("Gray: " + " Black: " + "Brown: ");
        }
    }
}
