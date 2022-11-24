namespace BoatBookingCore.Dto
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Certificates { get; set; }
    }
}
