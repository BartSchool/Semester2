using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatbookingDAL.DTO_s
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Certificates { get; set; }

        public UserDto(string name, bool isAdmin, string certificates)
        {
            Id = 0;
            Name = name;
            Password = name;
            IsAdmin = isAdmin;
            Certificates = certificates;
        }

        public UserDto(int id, string name)
        {
            Id = id;
            Name = name;
            Password = name;
            IsAdmin = false;
            Certificates = "";
        }

        public UserDto(int id, string name, bool isAdmin) : this(id, name)
        {
            IsAdmin = isAdmin;
        }

        public UserDto(int id, string name, bool isAdmin, string certificates) : this(id, name)
        {
            IsAdmin = isAdmin;
            Certificates = certificates;
        }
    }
}
