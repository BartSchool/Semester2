using System.Drawing;

namespace De_Kameleions.Core
{
    public class Kameleon
    {
        private ConsoleColor color;

        public Kameleon(ConsoleColor color)
        {
            this.color = color;
        }

        public void SeeOtherKameleon(ConsoleColor c)
        {
            color = c;
        }

        public ConsoleColor GetColor()
        {
            return color;
        }
    }
}