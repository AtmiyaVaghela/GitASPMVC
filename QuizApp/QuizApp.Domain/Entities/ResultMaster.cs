using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class ResultMaster : TimeLine
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("QuizMaster")]
        public int QuizMasterId { get; set; }
     
        [DefaultValue(0)]
        public int Trial { get; set; }

        [DefaultValue(0)]
        public int Result { get; set; }

        public virtual IEnumerable<QuizMaster> QuizMaster { get; set; }
    }
}
