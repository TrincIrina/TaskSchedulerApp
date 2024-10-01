using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Model
{
    // ToDoList - класс, описывающий список дел
    public class ToDoList
    {
        public int Id { get; set; }        // первичный ключ
        public string Title { get; set; }  // заголовок
        public int UserId { get; set; }    // идентификатор пользователя
        
        //навигационные свойства
        public User? User { get; set; }
        public List<Deal> Deals { get; set; } = [];
        public ToDoList()
        {
            Title = string.Empty;
        }
       
        public override string ToString()
        {
            return Title;
        }
    }
}
