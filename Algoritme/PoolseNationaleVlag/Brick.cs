using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolseNationaleVlag
{
    internal class Brick
    {
        private string color;

        Random rnd = new Random();
        public Brick()
        {
            if (rnd.Next(0, 2) == 1)
                color = "red";
            else
                color = "white";
        }

        public string GetColor()
        {
            return color;
        }
    }
}
