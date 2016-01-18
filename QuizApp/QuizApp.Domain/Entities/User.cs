using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class User : TimeLine
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please enter User Name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name must be 3 characters long.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Full Name.")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter E-mail ID.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please Select Role.")]
        public string Role { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
