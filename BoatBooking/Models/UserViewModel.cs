﻿using BoatBookingCore;

namespace BoatBookingView.Models
{
    public class UserViewModel
    {
        public Users users;
        public User User;

        public UserViewModel()
        {
            users = new Users();
            User = new User(0,"");
        }
    }
}
