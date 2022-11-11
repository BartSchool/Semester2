using System.Drawing;

public class Zoo
{
    private List<Kameleon>? kameleons;

    public Zoo()
    {

    }

    public void MakeKameleons(int black, int gray, int brown)
    {
        kameleons = new List<Kameleon>();
        for (int i = 0; i < black; i++)
            MakeKameleon(Color.Black) ;
        for (int i = 0; i < gray; i++)
            MakeKameleon(Color.Gray);
        for (int i = 0; i < brown; i++)
            MakeKameleon(Color.Brown);
    }

    private void MakeKameleon(Color c)
    {
        kameleons.Add(new Kameleon(c));
    }

    public List<Kameleon> GetKameleons()
    {
        return kameleons;
    }
}
