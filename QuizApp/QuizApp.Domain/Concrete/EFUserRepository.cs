using QuizApp.Domain.Abstract;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Entities.User> Users
        {
            get
            {
                return context.User.Where(t => t.Deleted == false);
            }
        }

        public void SaveUser(Entities.User user)
        {
            if ((Convert.ToString(user.ID)).Equals(""))
            {
                user.ID = new Guid();
                context.User.Add(user);
                context.SaveChanges();
                var g = context.User.Find(user.UserName);
                if (g != null)
                {
                    context.AuthenticationMaster.Add(CreateInitAuth(g.ID));
                }

            }
            else
            {
                User dbEntry = context.User.Find(user.ID);
                if (dbEntry != null)
                {
                    dbEntry.UserName = user.UserName;
                    dbEntry.FullName = user.FullName;
                    dbEntry.EmailID = user.EmailID;
                    dbEntry.Role = user.Role;
                }
                context.SaveChanges();
            }
        }

        private AuthenticationMaster CreateInitAuth(Guid g)
        {
            return new AuthenticationMaster { Password = "12345678", UserID = g };
        }

        public User DeleteUser(Guid userID)
        {
            User dbEntry = context.User.Find(userID);
            if (dbEntry != null)
            {
                dbEntry.Deleted = true;
            }
            return dbEntry;
        }
    }
}
