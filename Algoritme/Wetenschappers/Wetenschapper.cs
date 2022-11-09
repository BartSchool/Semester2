using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetenschappers
{
    internal class Wetenschapper
    {
        private string Name;
        private int Birth;
        private int Death;

        public Wetenschapper(string name, int birth, int death)
        {
            Name = name;
            Birth = birth;
            Death = death;
        }

        public string GetName() { return Name; }
        public int GetBirth() { return Birth; }
        public int GetDeath() { return Death; }
    }
}
