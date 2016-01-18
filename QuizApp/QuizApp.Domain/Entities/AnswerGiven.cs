using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class AnswerGiven
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("QuizGenerated")]
        public int QuizGeneratedID { get; set; }
      
        public string Answer { get; set; }

        public virtual IEnumerable<QuizGenerated> QuizGenerated { get; set; }
    }
}
