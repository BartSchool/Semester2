namespace De_Kameleions.Core
{
    public class Enclosure
    {
        public void GetEncounter(Kameleon a, Kameleon b)
        {
            Kameleon tempA = a;
            a.SeeOtherKameleon(b.GetColor());
            b.SeeOtherKameleon(tempA.GetColor());
        }
    }
}
