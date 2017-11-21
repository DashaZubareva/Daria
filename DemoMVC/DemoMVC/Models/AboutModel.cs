using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class AboutModel
    {
        public String  Message { get; set; }
        [Required (ErrorMessage ="Please enter mail!!!")]
        public String eMail { get; set; }
    }
   
}