using Microsoft.Build.Framework;

namespace BoatBookingView.Models;

public class AddUserViewModel
{
    [Required] public string UserName { get; set; }
    [Required] public bool IsAdmin { get; set; }
    public string? Certificates { get; set; }

    public bool NewIsAdmin { get; set; }
    public string? NewCertificates { get; set; }

    public AddUserViewModel()
    {

    }
}
