namespace VPT.Core.Classes;

public class row
{
    public List<chair> chairlist { get; private set; }
	public int number { get; private set; }

	public row(List<chair> chairlist, int number)
	{
		this.chairlist = chairlist;
		this.number = number;
	}

	public void addChair(chair chair)
	{
		chairlist.Add(chair);
	}

	public void removeChair(chair chair)
	{
		foreach (chair checkedChair in chairlist)
			if (checkedChair == chair)
			{
				chairlist.Remove(checkedChair);
				break;
			}
	}
}
