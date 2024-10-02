using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // ITodoListRepository - интерфейс сервиса для выполнения операций с сущностями ToDoList
    public interface ITodoListRepository
    {
        // добавление новой записи
        public ToDoList Add(ToDoList todo);
        // получение записей одного пользователя
        public List<ToDoList> ListAllByUser(string login);
        // получение записи по id
        public ToDoList? GetById(int id);
        // получение записи по имени
        public ToDoList? GetByName(string title);
        // удаление записи
        public ToDoList? DeleteById(int id);
        // обновление записи
        public ToDoList? Update(ToDoList toDoList);
    }
}
