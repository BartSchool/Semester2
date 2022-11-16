namespace De_Kameleions.Core
{
    public class Enclosure
    {
        private List<Kameleon> kameleons;
        private int[] count;
        private int tries;
        public bool isDone;

        public void DoEncounter(Kameleon a, Kameleon b)
        {
            Kameleon tempA = a;
            a.SeeOtherKameleon(b.GetColor());
            b.SeeOtherKameleon(tempA.GetColor());
            tries++;
        }

        public Kameleon GetRandomKameleon()
        {
            return kameleons[new Random().Next(0, kameleons.Count())];
        }
        public int[] GetCount()
        {
            updateCount();
            if (count[0] == kameleons.Count() || count[1] == kameleons.Count() || count[2] == kameleons.Count())
                isDone = true;
            return count;
        }
        public int GetTries()
        {
            return tries;
        }

        public void SetStartingKameleons()
        {
            kameleons = new List<Kameleon>();
            AddRedKameleons(14);
            AddGreenKameleons(15);
            AddBlueKameleons(10);

            count = new int[3] { 14, 15, 10 };
            tries = 0;
            isDone = false;
        }
        public void SetStartingKameleons(int r, int g, int b)
        {
            kameleons = new List<Kameleon>();
            AddRedKameleons(r);
            AddGreenKameleons(g);
            AddBlueKameleons(b);

            count = new int[3] { r, g, b };
            tries = 0;
            isDone = false;
        }

        private void AddGreenKameleons(int amount)
        {
            for (int i = 0; i < amount; i++)
                kameleons.Add(new Kameleon(ConsoleColor.Green));
        }
        private void AddRedKameleons(int amount)
        {
            for (int i = 0; i < amount; i++)
                kameleons.Add(new Kameleon(ConsoleColor.Red));
        }
        private void AddBlueKameleons(int amount)
        {
            for (int i = 0; i < amount; i++)
                kameleons.Add(new Kameleon(ConsoleColor.Blue));
        }

        private void updateCount()
        {
            count = new int[3] {0,0,0};

            foreach (Kameleon k in kameleons)
            switch (k.GetColor())
            {
                case ConsoleColor.Red:
                    count[0] += 1;
                    break;
                case ConsoleColor.Green:
                    count[1] += 1;
                    break;
                case ConsoleColor.Blue:
                    count[2] += 1;
                    break;

            }
        }


    }
}
