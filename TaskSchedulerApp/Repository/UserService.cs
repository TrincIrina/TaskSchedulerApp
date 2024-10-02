using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    public class UserService : IUserRepository
    {
        public User Add(User user)
        {
            using ApplicationDbContext db = new();            
            db.Users.Add(user);
            db.SaveChanges();
            return user;            
        }

        public User? DeleteByName(string name)
        {
            using ApplicationDbContext db = new();
            User? deletedUser = db.Users.FirstOrDefault(u => u.Login == name);
            if (deletedUser != null)
            {                    
                db.Users.Remove(deletedUser);
                db.SaveChanges();
            }
            return deletedUser;
        }

        public User? FindById(int id)
        {
            using ApplicationDbContext db = new();
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? FindByName(string name)
        {
            using ApplicationDbContext db = new();
            return db.Users.FirstOrDefault(u => u.Login == name);
        }

        public List<User> ListAll()
        {
            using ApplicationDbContext db = new();
            return db.Users.ToList();
        }

        public User? Update(User user)
        {
            using ApplicationDbContext db = new();
            User? updatedUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (updatedUser != null)
            {
                updatedUser.Login = user.Login;
                updatedUser.Password = user.Password;
                db.SaveChanges();
            }
            return updatedUser;
        }
    }
}
