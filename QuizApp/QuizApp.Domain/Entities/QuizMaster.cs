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
    public class QuizMaster : TimeLine
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        public int ChapterID { get; set; }

        [Required, ForeignKey("User")]
        public int UserID { get; set; }
   
        public DateTime ExpireDate { get; set; }

        [Required]
        public int NoOfQuestion { get; set; }

        public int MaxTrial { get; set; }

        [DefaultValue(0)]
        public int Trial { get; set; }

        public int MinResult { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<QuizGenerated> QuizGenerated { get; set; }
        public virtual IEnumerable<ResultMaster> Results { get; set; }
    }
}
