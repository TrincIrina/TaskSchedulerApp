// See https://aka.ms/new-console-template for more information

using TaskSchedulerApp.Model;
using TaskSchedulerApp.Repository;

IUserRepository userRepository = new UserService();
ITodoListRepository todoListRepository = new TodoService();
IDealRepository dealRepository = new DealService();
IItemRepository itemRepository = new ItemService();

User user = new()
{
    Login = "Лютый",
    Password = "123456"
};
userRepository.Add(user);

int userId = userRepository.FindByName("Лютый").Id;
List<ToDoList> toDoLists = new()
{
    new ToDoList()
    {
        Title = "Планы на выходные",
        UserId = userId
    },
    new ToDoList()
    {
        Title = "Личный",
        UserId = userId
    },
    new ToDoList()
    {
        Title = "Подготовка к Новому году",
        UserId = userId
    },
    new ToDoList()
    {
        Title = "Рабочий",
        UserId = userId
    },
};
foreach (ToDoList toDo in toDoLists)
{
    todoListRepository.Add(toDo);
}

int todoListId = todoListRepository.GetByName("Планы на выходные").Id;
List<Deal> deals = new()
{
    new Deal()
    {
        Name = "Выспаться",
        Priority = 2,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(7),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Встетиться с друзьями",
        Priority = 3,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(7),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Погулять в парке",
        Priority = 4,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(7),
        ToDoListId = todoListId
    },
};
foreach (Deal deal in deals)
{
    dealRepository.Add(deal);
}
todoListId = todoListRepository.GetByName("Личный").Id;
deals = new()
{
    new Deal()
    {
        Name = "Забрать посылку с почты",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(5),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Купить продукты",
        Priority = 2,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(1),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Погладить рубашки",
        Priority = 3,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(3),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Записаться к врачу",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(1),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Купить проездной",
        Priority = 3,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(7),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Сдать сумку в ремонт",
        Priority = 4,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(10),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Заказать банковскую выписку",
        Priority = 2,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(8),
        ToDoListId = todoListId
    },
};
foreach (Deal deal in deals)
{
    dealRepository.Add(deal);
}
todoListId = todoListRepository.GetByName("Подготовка к Новому году").Id;
deals = new()
{
    new Deal()
    {
        Name = "Обнаружить новогоднее настроение",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(2),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Поесть мандаринов",
        Priority = 5,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(2),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Разобраться со счетами",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(1),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Написать письмо деду Морозу",
        Priority = 4,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(1),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Написать цели на следующий год",
        Priority = 3,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(2),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Испечь имбирное печенье",
        Priority = 2,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(2),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Выбрать место празднования Нового года",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(14),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Записаться к парикмахеру и на маникюр",
        Priority = 2,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddDays(5),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Украсить дом, поставить ёлку",
        Priority = 3,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(1),
        ToDoListId = todoListId
    },
    new Deal()
    {
        Name = "Купить подурки, упаковать и подписать",
        Priority = 1,
        DateCreation = DateTime.Now,
        Deadline = DateTime.Now.AddMonths(1),
        ToDoListId = todoListId
    },
};
foreach (Deal deal in deals)
{
    dealRepository.Add(deal);
}

int dealId = dealRepository.GetByName("Разобраться со счетами").Id;
List<Item> items = new()
{
    new Item()
    {
        Number = 1,
        Description = "Заплатить налоги",
        DealId = dealId,
    },
    new Item()
    {
        Number = 2,
        Description = "Оплатить услги ЖКХ",
        DealId = dealId,
    },
    new Item()
    {
        Number = 3,
        Description = "Раздать долги",
        DealId = dealId,
    },
    new Item()
    {
        Number = 4,
        Description = "Спланировать бюджет на следущий год",
        DealId = dealId,
    },    
};
foreach (Item item in items)
{
    itemRepository.Add(item);
}
dealId = dealRepository.GetByName("Купить продукты").Id;
items = new()
{
    new Item()
    {
        Number = 1,
        Description = "Сыр",
        DealId = dealId,
    },
    new Item()
    {
        Number = 2,
        Description = "Творог",
        DealId = dealId,
    },
    new Item()
    {
        Number = 3,
        Description = "Йогурт",
        DealId = dealId,
    },
    new Item()
    {
        Number = 4,
        Description = "Спагетти",
        DealId = dealId,
    },
    new Item()
    {
        Number = 5,
        Description = "Круветки",
        DealId = dealId,
    },
    new Item()
    {
        Number = 6,
        Description = "вино полусухое белое",
        DealId = dealId,
    },
};
foreach (Item item in items)
{
    itemRepository.Add(item);
}