using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactCards.WebUI.Models
{
    public class ContactCardDBContext : DbContext
    {
        public ContactCardDBContext() : base("name=DbConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ContactCard> ContactCards { get; set; }
    }
}