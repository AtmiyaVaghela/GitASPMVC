using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
