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
        // добавление нового пользователя
        public User Add(User user)
        {
            using ApplicationDbContext db = new();            
            db.Users.Add(user);
            db.SaveChanges();
            return user;            
        }
        // получение пользователя по id
        public User? FindById(int id)
        {
            using ApplicationDbContext db = new();
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        // получение пользователя по имени
        public User? FindByName(string name)
        {
            using ApplicationDbContext db = new();
            return db.Users.FirstOrDefault(u => u.Login == name);
        }
    }
}
