using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Domain.Entities;

namespace QuizApp.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<User> MyProperty { get; set; }
        public DbSet<AuthenticationMaster> AuthenticationMaster { get; set; }
        public DbSet<QuizMaster> QuizMaster { get; set; }
        public DbSet<QuizGenerated> QuizGenerated { get; set; }
        public DbSet<AnswerGiven> AnswerGiven { get; set; }
        public DbSet<ResultMaster> ResultMaster { get; set; }
    }
}
