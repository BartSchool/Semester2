using De_Kameleions.Core;

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

        private int space = 14;

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
            Console.WriteLine(s);
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

        private void WriteKameleonsInEnclosure(Kameleon k1, Kameleon k2, int tries, int[] amount)
        {
            Console.Clear();
            if (tries <= 60)
            {
                if (tries >= 0 && 6 >= tries)
                {
                    writeEmptySpaces(4);
                    writeMiddle("Speeding up...");
                    writeEmptySpaces(5);
                }
                else if (tries >= 6 && 15 >= tries)
                {
                    writeEmptySpaces(4);
                    writeMiddle("Cant go faster...");
                    writeEmptySpaces(5);
                }
                else if (tries >= 50)
                {
                    writeEmptySpaces(4);
                    writeMiddle("Maybe if we get rid of this screen it will go faster...");
                    writeEmptySpaces(5);
                }
                else
                {
                    writeEmptySpaces(10);
                }
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
                writeMiddle("after " + tries + " tries..");
                writeMiddle("Red: " + amount[0] + " Green: " + amount[1] + " Blue: " + amount[2]);
            } else if (tries <= 120)
            {
                if (tries >= 90 && tries <= 100)
                {
                    writeEmptySpaces(7);
                    writeMiddle("Yeah that is defenitly faster");
                    writeEmptySpaces(6);
                } else
                {
                    writeEmptySpaces(14);
                }
                writeMiddle("after " + tries + " tries..");
                writeMiddle("Red: " + amount[0] + " Green: " + amount[1] + " Blue: " + amount[2]);
            } else
            {
                if (tries > 200)
                {
                    if (tries%4 == 0)
                    {
                        space = new Random().Next(0, 29);
                    }
                    writeEmptySpaces(space);
                } else
                {
                    writeEmptySpaces(space);
                }
                writeMiddle("after " + tries + " tries..");
                writeMiddle("Red: " + amount[0] + " Green: " + amount[1] + " Blue: " + amount[2]);
            }
        }

        public void showEncounter(Enclosure e)
        {
            int tries = e.GetTries();
            int pause;
            if (tries == 0)
                pause = 1000;
            else if (tries < 6)
            {
                pause = (1000 / tries) + 100;
            }
            else if (tries >= 6 && tries <= 60)
            {
                pause = (1000 / 6) +100;
            }
            else
                pause = (1000 / (tries-54)) + 100;

            Kameleon k1 = e.GetRandomKameleon();
            Kameleon k2 = e.GetRandomKameleon();

            if (tries <= 60)
            {
                if (k1.GetColor() != k2.GetColor())
                {
                    WriteKameleonsInEnclosure(k1, k2, e.GetTries(), e.GetCount());
                    e.DoEncounter(k1, k2);
                    Thread.Sleep(pause);
                    WriteKameleonsInEnclosure(k1, k2, e.GetTries(), e.GetCount());
                    Thread.Sleep(pause);
                }
            } else
            {
                if (k1.GetColor() != k2.GetColor())
                {
                    e.DoEncounter(k1, k2);
                    WriteKameleonsInEnclosure(k1, k2, e.GetTries(), e.GetCount());
                    Thread.Sleep(pause);
                }
            }
        }

        public void finishingScreen(Enclosure e)
        {
            Console.Clear();
            Console.ForegroundColor = e.GetRandomKameleon().GetColor();
            writeEmptySpaces(12);
            writeMiddle("After " + e.GetTries() + " tries we got all the kameleons to the same color :D");
            writeEmptySpaces(12);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
    }
}
