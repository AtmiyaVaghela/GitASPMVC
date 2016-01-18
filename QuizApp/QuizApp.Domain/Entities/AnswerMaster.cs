using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class AnswerMaster : TimeLine
    {
        [Key]
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string Answer { get; set; }

        public bool Flag { get; set; }

        public string Image { get; set; }
    }
}
