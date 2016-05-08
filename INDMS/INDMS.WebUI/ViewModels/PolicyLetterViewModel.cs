using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INDMS.WebUI.Models;

namespace INDMS.WebUI.ViewModels
{
    public class PolicyLetterViewModel
    {
        public PolicyLetter PLetter { get; set; }
        public string OIssuingAutherity { get; set; }
        public IEnumerable<PolicyLetter> PolicyLetters { get; set; }
    }
}