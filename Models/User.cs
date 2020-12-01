using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace portail.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public bool Status {
            get { return MyStatusAsInt == 0; }
            set { MyStatusAsInt = value ? 0 : 1; }
        }

        [Column("Status")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public int MyStatusAsInt { get; set; }

        public string Fullname()
        {
            return this.Firstname + "  " + this.Lastname;  
        }



    }
}