using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskSchedulerApp.Model;
using TaskSchedulerApp.Repository;

namespace TaskSchedulerApp_2._0
{
    /// <summary>
    /// Логика взаимодействия для ToDoListsWindow.xaml
    /// </summary>
    public partial class ToDoListsWindow : Window
    {
        private readonly IUserRepository userRepository = new UserService();
        private readonly ITodoListRepository todoListRepository = new TodoService();
        private List<ToDoList> lists = new(); // Список списков <ToDoList>
        private readonly User? user = new();
        private string title = null!;
        
        public ToDoListsWindow(string login)
        {
            InitializeComponent();

            lists = todoListRepository.ListAllByUser(login);

            user = userRepository.FindByName(login);
            Greeting();
            ToDoListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
        }
        // Вспомогательный метод для вывода приветствия
        private void Greeting()
        {
            DateTime now = DateTime.Now.AddHours(10);
            if (now.Hour >= 6 && now.Hour <= 12)
            {
                GreetingLabel.Content = "Доброе утро, " + user.Login + "!";
            } else if (now.Hour > 12 && now.Hour < 18)
            {
                GreetingLabel.Content = "Добрый день, " + user.Login + "!";
            } else if (now.Hour >= 18 && now.Hour <= 22)
            {
                GreetingLabel.Content = "Добрый вечер, " + user.Login + "!";
            } else
            {
                GreetingLabel.Content = user.Login + ", пора ложиться спать!";
            }
        }
        // Метод для закрытия приложения
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите закрыть приложение?",
                "Exit",
                MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
        // Метод для добавления списка
        private void AddListButton_Click(object sender, RoutedEventArgs e)
        {
            title = ToDoListTextBox.Text;
            if (title == null)
            {
                MessageBox.Show("Введите название списка");
            }
            ToDoList list = new()
            {
                Title = title,
                UserId = user.Id
            };
            todoListRepository.Add(list);
            ToDoListTextBox.Clear();
            ToDoListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
            title = null!;
        }
        // Метод для удаления списка
        private void DeleteListButton_Click(object sender, RoutedEventArgs e)
        {
            title = ToDoListBox.SelectedItem.ToString();
            if (title == null!)
            {
                MessageBox.Show("Выберите список для удаления");
            }
            else
            {
                int id = todoListRepository.GetByName(title).Id;
                todoListRepository.DeleteById(id);                
                ToDoListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
                title = null!;
            }            
        }
        // Метод для редактирования списка
        private void EditListButton_Click(object sender, RoutedEventArgs e)
        {
            title = ToDoListBox.SelectedItem.ToString();
            if (title == null!)
            {
                MessageBox.Show("Выберите список для редактирования");
            }
            else
            {
                int id = todoListRepository.GetByName(title).Id;
                title = null!;
                title = ToDoListTextBox.Text;
                if (title == null)
                {
                    MessageBox.Show("Введите название списка");
                }
                else
                {
                    ToDoList todo = new()
                    {
                        Id = id,
                        Title = title,
                        UserId = user.Id
                    };
                    todoListRepository.Update(todo);
                    ToDoListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
                    ToDoListTextBox.Clear();
                    title = null!;
                }
            }
        }
        // Метод для открытия списка дел
        private void OpenListButton_Click(object sender, RoutedEventArgs e)
        {
            int ToDoListId = 0;
            if (ToDoListBox.ItemsSource == null)
            {
                MessageBox.Show("Список задач пуст");
            }
            else
            {
                title = ToDoListBox.SelectedItem.ToString();
                foreach (ToDoList list in lists)
                {
                    if (list.Title == title)
                    {
                        ToDoListId = list.Id;
                    }
                }
                if (title == null)
                {
                    MessageBox.Show("Выберите список");
                }
                else
                {
                    DealsWindow dealsWindow = new(ToDoListId, user.Login);                    
                    dealsWindow.ShowDialog();                    
                    Close();
                }
            }
        }
    }
}
