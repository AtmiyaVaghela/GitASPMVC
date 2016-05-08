using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INDMS.WebUI.Models;

namespace INDMS.WebUI.ViewModels
{
    public class StandardViewModel
    {
        public Standard Standard { get; set; }
        public string OSubject { get; set; }
        public string OType { get; set; }
        public IEnumerable<Standard> Standards { get; set; }
    }
}