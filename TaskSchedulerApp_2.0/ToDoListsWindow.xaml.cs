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
        public IUserRepository userRepository = new UserService();
        public ITodoListRepository todoListRepository = new TodoService();        
        public User? user = new User();
        
        public ToDoListsWindow(string login)
        {
            InitializeComponent();

            user = userRepository.FindByName(login);
            Greeting();            
            ToDoListsListBox.ItemsSource = todoListRepository.ListAllByUser(user.Login);
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
    }
}
