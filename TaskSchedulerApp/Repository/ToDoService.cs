using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp.Repository
{
    // TodoService - сервис для выполнения операций с сущностями ToDoList
    public class TodoService : ITodoListRepository
    {
        // добавление новой записи
        public ToDoList Add(ToDoList todo)
        {
            using ApplicationDbContext db = new();
            db.ToDoLists.Add(todo);
            db.SaveChanges();
            return todo;
        }
        // получение всех записей одного пользователя
        public List<ToDoList> ListAllByUser(string login)
        {
            using ApplicationDbContext db = new();
            User? user = db.Users.FirstOrDefault(u => u.Login == login);
            if (user == null)
            {
                return new();
            }
            List<ToDoList> list = db.ToDoLists.Where(tl => tl.UserId == user.Id).ToList();
            return list;
        }

        // получение записи по id
        public ToDoList? GetById(int id)
        {
            using ApplicationDbContext db = new();
            return db.ToDoLists.FirstOrDefault(todo => todo.Id == id);
        }
        // получение записи по имени
        public ToDoList? GetByName(string title)
        {
            using ApplicationDbContext db = new();
            return db.ToDoLists.FirstOrDefault(todo => todo.Title == title);
        }

        // удаление записи
        public ToDoList? DeleteById(int id)
        {
            ToDoList? deletedTodo = GetById(id);
            if (deletedTodo != null)
            {
                using ApplicationDbContext db = new();
                db.ToDoLists.Remove(deletedTodo);
                db.SaveChanges();
            }
            return deletedTodo;
        }

        // обновление записи
        public ToDoList? Update(ToDoList toDoList)
        {
            using ApplicationDbContext db = new();
            ToDoList? updatedTodo = db.ToDoLists.FirstOrDefault(todo => todo.Id == toDoList.Id);
            if (updatedTodo != null)
            {
                updatedTodo.Title = toDoList.Title;
                db.SaveChanges();
            }
            return updatedTodo;
        }
    }
}
