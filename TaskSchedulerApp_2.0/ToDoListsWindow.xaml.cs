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
        private User? user = new();
        private string title = null!;
        
        public ToDoListsWindow(string login)
        {
            InitializeComponent();

            user = userRepository.FindByName(login);
            Greeting();
            ToDoListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
        }
        // Вспомогательный метод для вывода приветствия
        private void Greeting()
        {
            DateTime now = DateTime.Now;
            if (now.Hour >= 6 && now.Hour <= 12)
            {
                GreetingLabel.Content = "Доброе утро, " + user.Login + "!";
            } else if (now.Hour > 12 && now.Hour < 17)
            {
                GreetingLabel.Content = "Добрый день, " + user.Login + "!";
            } else if (now.Hour >= 17 && now.Hour <= 21)
            {
                GreetingLabel.Content = "Добрый вечер, " + user.Login + "!";
            } else
            {
                GreetingLabel.Content = "Доброй ночи, " + user.Login + "!";
            }
        }
        
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

        private void OpenListButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoListBox.ItemsSource == null)
            {
                MessageBox.Show("Список задач пуст");
            }
            else
            {
                title = ToDoListBox.SelectedItem.ToString();
                if (title == null)
                {
                    MessageBox.Show("Выберите список");
                }
                else
                {
                    DealsWindow dealsWindow = new(title);
                    this.Hide();
                    dealsWindow.ShowDialog();
                    this.Show();
                    title = null!;
                }
            }
        }
    }
}
