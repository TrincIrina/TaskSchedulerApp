// See https://aka.ms/new-console-template for more information

using TaskSchedulerApp.Model;
using TaskSchedulerApp.Repository;

IUserRepository userRepository = new UserService();
ITodoListRepository todoListRepository = new TodoService();
IDealRepository dealRepository = new DealService();
IItemRepository itemRepository = new ItemService();

