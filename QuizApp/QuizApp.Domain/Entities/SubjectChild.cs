using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class SubjectChild : TimeLine
    {
        [Key]
        public int ID { get; set; }

        public int SubjectID { get; set; }

        public string ChapterName { get; set; }

        public string ChapterDescription { get; set; }
    }
}
