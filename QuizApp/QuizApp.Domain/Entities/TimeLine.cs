using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Domain.Entities
{
    public class TimeLine
    {
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }
    }
}
