using VPT.Core.Classes;
using VPT.Core.Dto_s;

namespace VPT.view.Models;

public class EventViewModel
{
    public EventCollection _events { get; set; }
	public DtoEvent removeEvent { get; set; }
	public string name { get; set; }
    public int amount { get; set; }
    public DateTime start {get; set; }
    public DateTime end {get; set; }

	public EventViewModel()
	{

	}
}
