
public class Data
{
    private string Cameleonr1 = " ╱▉▔▉▔▉▔▉╲▕▔╲      ";
    private string Cameleonr2 = "╱▕▋▕▋▕▋▕▋┈▔┈╰╲     ";
    private string Cameleonr3 = "▏▕▎▕▎▕▎▕▎┈▕▔╲╰╲    ";
    private string Cameleonr4 = "▏╱▔▔╲▂┊┊▂▂▏╲▇▏▕    ";
    private string Cameleonr5 = "▏▏╱╲▕ ╲╰╲ ╲╰━━━━╮  ";
    private string Cameleonr6 = "╲╲▏╱▕  ╲╰▔▏▔▔▔ ╰╯  ";
    private string Cameleonr7 = " ╲▂▂╱   ▔▔         ";
                                //"0123456789012345678"

    public List<string> CameleonArtRight()
    {
        List<string> list = new List<string>() { Cameleonr1, Cameleonr2, Cameleonr3, Cameleonr4, Cameleonr5, Cameleonr6, Cameleonr7 };
        return list;
    }

    public List<string> CameleonArtLeft()
    {
        List<string> list = new List<string>() { R(Cameleonr1), R(Cameleonr2), R(Cameleonr3), R(Cameleonr4), R(Cameleonr5), R(Cameleonr6), R(Cameleonr7) };
        return list;
    }

    private static string R(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
