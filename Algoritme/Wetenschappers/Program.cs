using Wetenschappers;
using System.Diagnostics;

List<Wetenschapper> wetenschappers = new List<Wetenschapper>();

string[] data = {"Albert Einstein;1879;1955",
"Alessandro Volta;1745;1827",
"Alexander Fleming;1881;1955",
"Alexander Graham Bell;1847;1922",
"Alfred Nobel;1833;1896",
"Amedeo Avogadro;1776;1856",
"André - Marie Ampère;1775;1836",
"Antoine Henri Becquerel;1852;1908",
"Antoine Lavoisier;1743;1794",
"Blaise Pascal;1623;1662",
"Carl Friedrich Gauss;1777;1855",
"Carl Sagan;1934;1996",
"Charles Darwin;1809;1882",
"Charles - Augustin de Coulomb;1736;1806",
"Edwin Hubble;1889;1953",
"Enrico Fermi;1901;1954",
"Evangelista Torricelli;1608;1647",
"Francis Crick;1916;2004",
"Galileo Galilei;1564;1642",
"Gottfried Wilhelm Leibniz;1646;1716",
"Gregor Mendel;1822;1884",
"Guglielmo Marconi;1874;1937",
"Heinrich Hertz;1857;1894",
"Isaac Newton;1642;1727",
"James Clerk Maxwell;1831;1879",
"James Prescott Joule;1818;1889",
"Johannes Kepler;1571;1630",
"John Dalton;1766;1844",
"John von Neumann;1903;1957",
"Leonardo da Vinci;1452;1519",
"Leonhard Euler;1707;1783",
"Louis Pasteur;1822;1895",
"Ludwig Boltzmann;1844;1906",
"Marie Curie;1867;1934",
"Max Planck;1858;1947",
"Michael Faraday;1791;1867",
"Nicolaas Copernicus;1473;1543",
"Niels Bohr;1885;1962",
"'Nikola Tesla;1856;1943",
"Paul Dirac;1902;1984",
"Pierre Curie;1859;1906",
"René Descartes;1596;1650",
"Robert Boyle;1627;1691",
"Subramanyan Chandrasekhar;1910;1995",
"Wilhelm Röntgen;1845;1923",
"William Thomson;1824;1907" };

foreach (string s in data)
{
    List<char> name = new List<char>();
    List<char> b = new List<char>();
    List<char> d = new List<char>();
    int count = 0;
    for (int i = 0; i < s.Length; i++)
    {
        char c = s[i];
        if (c == ';') { count++; }
        else if (count == 0) { name.Add(c); }
        else if (count == 1) { b.Add(c); }
        else if (count == 2) { d.Add(c); }
    }

    wetenschappers.Add(new Wetenschapper(new string(name.ToArray()), int.Parse(new string(b.ToArray())), int.Parse(new string(d.ToArray()))));
}


List<int[]> list = new List<int[]>();
int alive = 0;
int year = 0;
int start = 2147483647;
int end = -2147483648;
Stopwatch Stopwatch = new Stopwatch();

foreach (Wetenschapper wet in wetenschappers)
{
    int d = wet.GetDeath();
    int b = wet.GetBirth();
    if (b < start) { start = b; }
    if (d > end) { end = d; }
}

Stopwatch.Start();
for (int i = start; i <= end; i++)
{
    int[] a = { i, GetAliveIn(i) };
    list.Add(a);
}
foreach (int[] a in list)
{
    if (a[1] > alive) { year = a[0]; alive = a[1]; }
}
Stopwatch.Stop();

Console.WriteLine($"The year with the most scientist was {year}");
Console.WriteLine($"\nElapsed Time to sort {Stopwatch.Elapsed.TotalMilliseconds} ms");

int GetAliveIn(int year)
{
    int amount = 0;
    foreach (Wetenschapper wetenschapper in wetenschappers)
        if (wetenschapper.GetBirth() <= year && wetenschapper.GetDeath() > year)
            amount++;

    return amount;
}