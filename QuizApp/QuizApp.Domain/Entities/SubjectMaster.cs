using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class SubjectMaster :TimeLine
    {
        [Key]
        public int ID { get; set; }

        public string SubjectName { get; set; }

        public string SubjectDescription { get; set; }
    }
}

