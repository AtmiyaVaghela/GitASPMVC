using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QuizApp.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<AuthenticationMaster> AuthenticationMaster { get; set; }

        public DbSet<QuizMaster> QuizMaster { get; set; }
        public DbSet<ResultMaster> ResultMaster { get; set; }

        public DbSet<QuizGenerated> QuizGenerated { get; set; }
        public DbSet<AnswerGiven> AnswerGiven { get; set; }
 

        public DbSet<SubjectChild> SubjectChild { get; set; }
        public DbSet<SubjectMaster> SubjectMaster { get; set; }

        public DbSet<QuestionMaster> QuestionMaster { get; set; }
        public DbSet<AnswerMaster> AnswerMaster { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
