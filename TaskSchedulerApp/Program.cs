// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using TaskSchedulerApp.Model;
using TaskSchedulerApp.Repository;

IUserRepository userRepository = new UserService();
ITodoListRepository todoListRepository = new TodoService();
IDealRepository dealRepository = new DealService();
IItemRepository itemRepository = new ItemService();

//for(int i = 0; i <3; i++)
//{
//    Console.Write("Login: ");
//    string login = Console.ReadLine();
//    Console.Write("Password: ");
//    string password = Console.ReadLine();
//    User user = userRepository.Add(new User()
//    {
//        Login = login,
//        Password = password
//    });
//}

//userRepository.ListAll().ToList().ForEach(u => Console.WriteLine($"{u.Id} - {u}"));

//for (int i = 0; i < 5; i++)
//{
//    Console.Write("Title: ");
//    string title = Console.ReadLine();
//    Console.Write("User id: ");
//    int userId = Convert.ToInt32(Console.ReadLine());
//    ToDoList toDoList = todoListRepository.Add(new ToDoList()
//    {
//        Title = title,
//        UserId = userId
//    });
//}

List<User> users = userRepository.ListAll();
//foreach (User user in users)
//{
//    Console.WriteLine($"{user.Id} - {user}");
//    todoListRepository.ListAll(user.Login).ToList().ForEach(tl => Console.WriteLine($"\t{tl.Id} - {tl}"));
//    Console.WriteLine();
//}

//for (int i = 0; i < 8; i++)
//{
//    Console.Write("Name: ");
//    string name = Console.ReadLine();
//    Console.Write("Priority: ");
//    int priority = Convert.ToInt32(Console.ReadLine());
//    Console.Write("Deadline: ");
//    DateTime deadline = Convert.ToDateTime(Console.ReadLine());
//    Console.Write("ToDoList id: ");
//    int toDoListId = Convert.ToInt32(Console.ReadLine());
//    Deal deal = dealRepository.Add(new Deal()
//    {
//        Name = name,
//        Priority = priority,
//        DateCreation = DateTime.Now,
//        Deadline = deadline,
//        ToDoListId = toDoListId
//    });
//}

//foreach (User u in users)
//{
//    Console.WriteLine($"{u.Id} - {u});");
//    List<ToDoList> list = todoListRepository.ListAllByUser(u.Login);
//    foreach (ToDoList tl in list)
//    {
//        Console.WriteLine($"\t{tl.Id} - {tl}");
//        dealRepository.ListAllByToDoList(tl.Title).ToList().ForEach(d => Console.WriteLine($"\t\t{d.Id} - {d}"));
//        Console.WriteLine();
//    }
//    Console.WriteLine();
//}

//Console.Write("Id user: ");
//int id = Convert.ToInt32(Console.ReadLine());
//Console.Write("Login: ");
//string login = Console.ReadLine();
//Console.Write("Password: ");
//string password = Console.ReadLine();
//User user = new User()
//{
//    Id = id,
//    Login = login,
//    Password = password
//};
//userRepository.Update(user);

//Console.WriteLine("ToDoList id: ");
//int id = Convert.ToInt32(Console.ReadLine());
//Console.Write("Title: ");
//string title = Console.ReadLine();
//Console.Write("User id: ");
//int userId = Convert.ToInt32(Console.ReadLine());
//ToDoList? toDoList = new ToDoList()
//{
//    Id = id,
//    Title = title,
//    UserId = userId
//};
//todoListRepository.Update(toDoList);

//Console.Write("Deal id: ");
//id = Convert.ToInt32(Console.ReadLine());
//Console.Write("Name: ");
//string name = Console.ReadLine();
//Console.Write("Priority: ");
//int priority = Convert.ToInt32(Console.ReadLine());
//Console.Write("Deadline: ");
//DateTime deadline = Convert.ToDateTime(Console.ReadLine());
//Console.Write("ToDoList id: ");
//int toDoListId = Convert.ToInt32(Console.ReadLine());
//Deal deal = new Deal()
//{
//    Id = id,
//    Name = name,
//    Priority = priority,
//    DateCreation = DateTime.Now,
//    Deadline = deadline,
//    ToDoListId = toDoListId
//};
//dealRepository.Update(deal);

//for (int i = 0; i < 10; i++)
//{
//    Console.Write("Description: ");
//    string des = Console.ReadLine();
//    Console.Write("Deal id: ");
//    int dId = Convert.ToInt32(Console.ReadLine());
//    itemRepository.Add(new Item()
//    {
//        Description = des,
//        DealId = dId
//    });
//}

foreach (User u in users)
{
    Console.WriteLine($"{u.Id} - {u}");
    List<ToDoList> list = todoListRepository.ListAllByUser(u.Login);
    foreach (ToDoList tl in list)
    {
        Console.WriteLine($"\t{tl.Id} - {tl}");
        List<Deal> deals = dealRepository.ListAllByToDoList(tl.Title);
        foreach (Deal d in deals)
        {
            Console.WriteLine($"\t\t{d.Id} - {d}");
            itemRepository.ListAllByDeal(d.Id).ToList().ForEach(i => Console.WriteLine($"\t\t\t{i.Id} - {i}"));
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//Console.Write("Item id: ");
//int id = Convert.ToInt32(Console.ReadLine());
//itemRepository.DeleteById(id);

//Console.Write("Item id: ");
//id = Convert.ToInt32(Console.ReadLine());
//Console.Write("Description: ");
//string description = Console.ReadLine();
//Console.Write("Deal id: ");
//int dealId = Convert.ToInt32(Console.ReadLine());
//Item item = new Item()
//{
//    Id = id,
//    Description = description,
//    DealId = dealId
//};
//itemRepository.Update(item);

//Console.Write("ToDoList id: ");
//int id = Convert.ToInt32(Console.ReadLine());
//todoListRepository.DeleteById(id);

//Console.Write("Deal id: ");
//int id = Convert.ToInt32(Console.ReadLine());
//dealRepository.DeleteById(id);

Console.Write("User name: ");
string name = Console.ReadLine();
userRepository.DeleteByName(name);

foreach (User u in users)
{
    Console.WriteLine($"{u.Id} - {u}");
    List<ToDoList> list = todoListRepository.ListAllByUser(u.Login);
    foreach (ToDoList tl in list)
    {
        Console.WriteLine($"\t{tl.Id} - {tl}");
        List<Deal> deals = dealRepository.ListAllByToDoList(tl.Title);
        foreach (Deal d in deals)
        {
            Console.WriteLine($"\t\t{d.Id} - {d}");
            itemRepository.ListAllByDeal(d.Id).ToList().ForEach(i => Console.WriteLine($"\t\t\t{i.Id} - {i}"));
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}