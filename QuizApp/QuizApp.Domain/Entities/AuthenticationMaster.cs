using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entities
{
    public class AuthenticationMaster
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }

        //[Required,ForeignKey("User")]
        public Guid UserID { get; set; }        

        //public virtual User User { get; set; }
    }
}
