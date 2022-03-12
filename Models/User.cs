using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace portail.Models
{
    public class User: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
   
        public string Address { get; set; }

        public string Fullname()
        {
            return this.Firstname + "  " + this.Lastname;  
        }



    }

    public class UserViewModel
    {
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}