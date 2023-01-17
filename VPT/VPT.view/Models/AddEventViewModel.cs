using VPT.Core.Classes;
using VPT.Core.Dto_s;

namespace VPT.view.Models;

public class AddEventViewModel
{
    public DtoEvent DtoEvent { get; set; }
    public string name { get; set; }
    public int spaces { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public EventCollection _events { get; set; }

    public AddEventViewModel()
	{

	}
}
