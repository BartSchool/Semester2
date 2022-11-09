using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;

namespace BoatBooking.Models
{
    public class AddBoatViewModel
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public int? minWeight { get; set; }
        public int? maxWeight { get; set; }
        public string? authorised { get; set; }

        public AddBoatViewModel()
        {

        }
    }
}
