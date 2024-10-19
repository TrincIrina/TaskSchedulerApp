using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Model
{
    // Item - класс, описывающий пункт чек-листа
    public class Item
    {
        public int Id { get; set; }                 // первичный ключ
        public int Number { get; set; }             // порядковый номер
        public string Description { get; set; }     // описание
        public bool IsDone { get; set; } = false;   // отметка о выполнении задачи
        public int DealId { get; set; }             // внешний ключ

        // навигационное свойство
        public Deal? Deal { get; set; }             
        public Item()
        {
            Description = string.Empty;
        }
        public override string ToString()
        {
            return $"{Number}. {Description}";
        }
    }
}
