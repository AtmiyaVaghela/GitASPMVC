using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class QuizGenerated : TimeLine
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("QuizMaster")]
        public int QuizId { get; set; }

        public int QuestionID { get; set; }

        public int Trial { get; set; }

        public virtual IEnumerable<QuizMaster> QuizMaster { get; set; }
    }
}
