using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class QuestionMaster :TimeLine
    {
        [Key]
        public int ID { get; set; }

        public string Question { get; set; }

        public string Image { get; set; }

        public int SubjectID { get; set; }
    }
}
