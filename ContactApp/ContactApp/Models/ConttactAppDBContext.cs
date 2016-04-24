using System.Data.Entity;

namespace ContactApp.Models
{
    public class ConttactAppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}