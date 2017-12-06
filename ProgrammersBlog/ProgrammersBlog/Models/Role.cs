using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public int RoleName { get; set; }
        public int Description { get; set; }
        public bool Deleted { get; set; }

        public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }

    }
}