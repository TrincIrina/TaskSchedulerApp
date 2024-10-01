using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Model
{
    // User - класс, описывающий пользователя
    public class User
    {
        public int Id { get; set; }        
        public string Login { get; set; }
        public string Password { get; set; }

        // навигационные свойства
        public List<ToDoList> ToDoLists { get; set; } = [];
        public User()
        {            
            Login = string.Empty;
            Password = string.Empty;
        }
        public override string ToString()
        {
            return Login;
        }
    }

}
