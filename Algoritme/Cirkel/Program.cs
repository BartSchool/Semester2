using Cirkel;

List<Lamp> lamps = new List<Lamp>();
List<Switch> switchs = new List<Switch>();
int amount = 14;

for (int i = 0; i < amount; i++)
    lamps.Add(new Lamp());

for (int i = 0; i < amount; i++)
{
    List<Lamp> lampen = new List<Lamp>();
    if (i-1 < 0) 
    {
        lampen.Add(lamps.Last());
        lampen.Add(lamps[i + 1]);
    }
    else if (i+2 > lamps.Count)
    {
        lampen.Add(lamps[i-1]);
        lampen.Add(lamps.First());
    }
    else
    {
        lampen.Add(lamps[i - 1]);
        lampen.Add(lamps[i + 1]);
    }
    lampen.Add(lamps[i]);
    switchs.Add(new Switch(lampen));
}

Solve();

void WriteLampStates()
{
    foreach (Lamp l in lamps)
        if (l.IsOn())
            Console.WriteLine("Lamp: On");
        else
            Console.WriteLine("Lamp: Off");
}

void FlickAllSwitches()
{
    foreach (Switch sw in switchs)
        sw.flick();

    Console.WriteLine("- - - - FLICKING - - - -");
    WriteLampStates();
}

void FlickSwitch(int i)
{
    switchs[i].flick();
    Console.WriteLine("- - - - FLICKING - - - -");
    WriteLampStates();
}

void Solve()
{
    Console.WriteLine("start configuration:");
    WriteLampStates();

    Console.WriteLine("- - - - SOLVING - - - -");
    int length = lamps.Count();
    int i = 0;
    while (length > 4)
    {
        if (!lamps[i].IsOn())
            FlickSwitch(i + 1);
        i++;
        length--;
    }

    Console.WriteLine("- - - - SOLVED - - - -");
    WriteLampStates();
}