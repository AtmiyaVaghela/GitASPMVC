using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class ConttactAppDBContext : DbContext
    {
        DbSet<User> Users { get; set; }
    }
}