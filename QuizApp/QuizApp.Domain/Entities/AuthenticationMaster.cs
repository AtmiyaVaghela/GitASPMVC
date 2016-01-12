using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Domain.Entities
{
    public class AuthenticationMaster
    {
        public Guid ID { get; set; }

        public Guid UserID { get; set; }

        [Required(ErrorMessage="Please enter Password.")]
        public string Password { get; set; }

    }
}
