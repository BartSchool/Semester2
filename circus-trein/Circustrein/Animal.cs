using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Animal
    {
        private string Size;
        private string Name;
        private string Dieet;
        private int sizePoints;

        public Animal(string size, string name, string dieet)
        {
            Size = size;
            Name = name;

            if (size == "small")
            {
                sizePoints = 1;
            }
            else if (size == "avarage")
            {
                sizePoints = 3;
            }
            else if (size == "big")
            {
                sizePoints = 5;
            }

            if (dieet == "c")
            {
                Dieet = "carnivore";
            }
            else if (dieet == "h")
            {
                Dieet = "herbivore";
            }
        }

        public string GetDieet()
        {
            return Dieet;
        }

        public int GetSizePoints()
        {
            return sizePoints;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSize()
        {
            return Size;
        }
    }
}
