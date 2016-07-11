using ContactCards.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactCards.WebUI.ViewModel
{
    public class ContactCardViewModel
    {
        public IEnumerable<ContactCard> CC { get; set; }
        public ContactCard C { get; set; }
    }
}