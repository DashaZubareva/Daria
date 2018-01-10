using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public DateTime Birthday { get; set; }
        public string  Avatar { get; set; }
        public string Password { get; set; }

        public ICollection<RoleModel> Roles { get; set; }
        public UserModel()
        {
            Roles = new List<RoleModel>();
        }

    }
}