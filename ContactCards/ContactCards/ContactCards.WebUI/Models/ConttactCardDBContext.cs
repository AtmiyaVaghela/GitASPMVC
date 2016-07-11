using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactCards.WebUI.Models
{
    public class ConttactCardDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContactCard> ContactCards { get; set; }
    }
}