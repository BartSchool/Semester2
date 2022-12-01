namespace Circustrein;

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
