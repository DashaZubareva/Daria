using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string BodyComments { get; set; }
        public int UserId { get; set; }
        public bool Deleted { get; set; }
        public int PostId { get; set; }
        public int ParentCommId { get; set; }
        public DateTimeOffset InitialTime { get; set; }

        public PostModel Post { get; set; }
        


    }
}