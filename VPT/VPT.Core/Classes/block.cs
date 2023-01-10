namespace VPT.Core.Classes;

public class block
{
    public List<row> rowlist { get; private set; }
    public string name { get; private set; }

    public block(List<row> rowlist, string name)
    {
        this.rowlist = rowlist;
        this.name = name;
    }
}
