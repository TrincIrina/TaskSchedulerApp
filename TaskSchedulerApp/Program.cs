// See https://aka.ms/new-console-template for more information

using TaskSchedulerApp.Model;
using TaskSchedulerApp.Repository;

IUserRepository userRepository = new UserService();
ITodoListRepository todoListRepository = new TodoService();
IDealRepository dealRepository = new DealService();
IItemRepository itemRepository = new ItemService();

List<User> users = userRepository.ListAll();

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