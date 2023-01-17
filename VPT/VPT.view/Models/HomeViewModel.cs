using VPT.Core.Classes;

namespace VPT.view.Models;

public class HomeViewModel
{
    public EventCollection EventCollection { get; set; }
    public string EventName { get; set; }
	public string[] UserName { get; set; }
	public DateTime[] BirthDate { get; set; }

	public HomeViewModel()
	{

	}
}
