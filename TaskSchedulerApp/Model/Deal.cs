using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Model
{
    // Deal - класс, описывающий пункт списка дел
    public class Deal
    {
        public int Id { get; set; }                 // первичный ключ
        public string Name { get; set; }            // название
        public int Priority { get; set; }           // приоритет
        public DateTime DateCreation { get; set; }  // дата создания
        public DateTime Deadline { get; set; }      // дата, к которой дело должно быть выполнено
        public bool IsDone { get; set; } = false;   // отметка о выполнении пункта
        public int ToDoListId { get; set; }         // внешний ключ

        // навигационные свойства
        public ToDoList? ToDoList { get; set; }     
        public List<Item> Items { get; set; } = [];

        public Deal()
        {
            Name = string.Empty;            
        }
        public override string ToString()
        {
            return $"{Name}. {Priority} - {DateCreation} - {Deadline}";
        }

    }
}
