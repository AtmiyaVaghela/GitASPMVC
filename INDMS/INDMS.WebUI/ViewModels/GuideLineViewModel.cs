using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INDMS.WebUI.Models;

namespace INDMS.WebUI.ViewModels
{
    public class GuideLineViewModel
    {
        public GuideLine GuideLine { get; set; }
        public string OIssuingAutherity { get; set; }
       public IEnumerable<GuideLine> GuideLines { get; set; }
    }
}