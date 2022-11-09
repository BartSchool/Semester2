using PoolseNationaleVlag;
using System.Diagnostics;

List<Brick> bricks = new List<Brick>();
Stopwatch Stopwatch = new Stopwatch();

MakeWall(20);
DisplayWall();
Stopwatch.Start();
SortAllBricks();
Stopwatch.Stop();
DisplayWall();

Console.WriteLine($"\nElapsed Time to sort {Stopwatch.Elapsed.TotalMilliseconds} ms");


void MakeWall(int size)
{
    Console.WriteLine("\nNewly generated brick wall");
    for (int i = 0; i < size; i++)
        bricks.Add(new Brick());
}

void DisplayWall()
{
    foreach (Brick brick in bricks)
    {
        if (brick.GetColor() == "white")
            Console.ForegroundColor = ConsoleColor.White;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("###");
    }
    Console.ForegroundColor = ConsoleColor.White;
}

void SwapBrick(int from, int to)
{
    Brick tempBrick = bricks[to];
    bricks[to] = bricks[from];
    bricks[from] = tempBrick;
}

bool IsRedBrick(Brick brick)
{
    if (brick.GetColor() == "red")
        return true;
    return false;
}

void SortAllBricks()
{
    Console.WriteLine("\nSorted wall");
    int j = 0;
    int i = bricks.Count-1;
    while (j < i)
    {
        if (IsRedBrick(bricks[i]))
        {
            bool succes = false;
            while (!succes && j < i)
            {
                if (!IsRedBrick(bricks[j]))
                {
                    SwapBrick(i, j);
                    succes = true;
                }
                j++;
            }
        }
        i--;
    }
}