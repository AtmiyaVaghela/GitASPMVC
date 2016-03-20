using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactBook.Models;

namespace ContactBook.ViewModel
{
    public class UserMasterViewModel
    {
        public UserMaster UserMaster { get; set; }
        public IEnumerable<UserMaster> UserMasters { get; set; }
    }
}