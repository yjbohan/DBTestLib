using System;
using System.Collections.Generic;

namespace DBTestLib
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Isreviewer { get; set; }
        public bool Isadmin { get; set; }

        public virtual Request Request { get; set; }
    }
}
