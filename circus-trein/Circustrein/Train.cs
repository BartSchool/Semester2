using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Train
    {
        public List<Cart> carts = new List<Cart>();

        public Train()
        {

        }

        public void AddCart(Cart cart)
        {
            carts.Add(cart);
        }

        public List<Cart> GetCarts()
        {
            return carts;
        }
    }
}
