using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INDMS.WebUI.Models;

namespace INDMS.WebUI.ViewModels
{
    public class StandingOrderViewModel
    {
        public StandingOrder StandingOrder { get; set; }
        public string OIssuingAutherity { get; set; }
        public string OSubject { get; set; }
        public IEnumerable<StandingOrder> StandingOrders { get; set; }
    }
}