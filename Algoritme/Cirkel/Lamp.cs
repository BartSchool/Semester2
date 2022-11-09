namespace Cirkel
{
    internal class Lamp
    {
        private bool on = false;

        public Lamp()
        {
            if (new Random().Next(0,2) == 1)
                on = true;
        }

        public void Switch()
        {
            if (on)
                on = false;
            else
                on = true;
        }

        public bool IsOn()
        {
            return on;
        }
    }
}
