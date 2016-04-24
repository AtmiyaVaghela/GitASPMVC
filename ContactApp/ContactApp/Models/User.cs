using System;
using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }

        [Display(Name = "Email Id"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}