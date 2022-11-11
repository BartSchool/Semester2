using System.Drawing;

namespace DeKameleons.Core
{
    public class Kameleon
    {
        private Color color;

        public Kameleon(Color c)
        {
            color = c;
        }

        public void SeeKameleon(Kameleon kameleon)
        {
            color = kameleon.color;
        }
    }
}
