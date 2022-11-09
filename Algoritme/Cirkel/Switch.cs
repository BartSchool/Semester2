namespace Cirkel
{
    internal class Switch
    {
        private List<Lamp> lampen = new List<Lamp>();

        public Switch(List<Lamp> lamps)
        {
            lampen = lamps;
        }

        public void flick()
        {
            foreach (Lamp lamp in lampen)
                lamp.Switch();
        }
    }
}
