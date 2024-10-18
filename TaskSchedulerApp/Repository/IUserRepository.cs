using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // IUserRepository - интерфейс сервиса для выполнения операций с сущностями User
    public interface IUserRepository
    {
        // добавление нового пользователя
        public User Add(User user);
        
        // получение пользователя по id
        public User? FindById(int id);

        // получение пользователя по имени
        public User? FindByName(string name);
        
    }
}
