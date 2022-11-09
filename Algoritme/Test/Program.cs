List<int> moves = new List<int>();
Random rnd = new Random();
bool[] bite = NewByte(4);

main();

void main()
{
    bool finished = false;
    while(!finished)
    {
        WriteLamps();
        moves.Add(GetMove());
        if (bite.All(x => x))
            finished = true;
    }

    Console.Write("|");
    foreach (int move in moves)
        Console.Write(move);
    Console.Write("|");
}

bool[] NewByte(int length)
{
    bool[] bite = new bool[length];
    for (int i = 0; i < length; i++)
        if (rnd.Next(0, 2) == 1)
            bite[i] = false;
        else
            bite[i] = true;

    return bite;
}

int GetMove()
{
    int m;
    m = int.Parse(Console.ReadLine());
    if (m-1 < 0)
    {
        bite[bite.Length - 1] = !bite[bite.Length - 1];
        bite[m + 1] = !bite[m + 1];
    }
    else if (m + 1 > bite.Length)
    {
        bite[m - 1] = !bite[m - 1];
        bite[0] = !bite[0];
    }
    else
    {
        bite[m - 1] = !bite[m - 1];
        bite[m + 1] = !bite[m + 1];
    }
    bite[m] = !bite[m];
    return m;
}

void WriteLamps()
{
    Console.Write("\n|");
    foreach (bool i in bite)
        if (i)
            Console.Write(1);
        else
            Console.Write(0);
    Console.Write("|");
}