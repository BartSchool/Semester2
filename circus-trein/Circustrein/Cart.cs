using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Cart
    {
        private int Space;
        private List<Animal> Animals = new List<Animal>();
        private bool CarnivoreOnBoard;
        private int CarnivoreSize;

        public Cart()
        {
            Space = 10;
            CarnivoreOnBoard = false;
            CarnivoreSize = 0;
        }

        public Cart(int space)
        {
            Space = space;
            CarnivoreOnBoard = false;
            CarnivoreSize = 0;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Space -= animal.GetSizePoints();
        }

        public List<Animal> GetAnimals()
        {
            return Animals;
        }

        public bool IsSpace(Animal animal)
        {
            if ((Space - animal.GetSizePoints()) < 0)
            {
                return false;
            }
            return true;
        }

        public int getSpace()
        {
            return Space;
        }

        public void SetCarnivoreOnBoard(bool a)
        {
            CarnivoreOnBoard = a;
        }

        public bool IsCarnivoreOnBoard()
        {
            return CarnivoreOnBoard;
        }

        public void SetCarnivoreSize(int b)
        {
            CarnivoreSize = b;
        }

        public int GetCarnivoreSize()
        {
            return CarnivoreSize;
        }
    }
}
