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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskSchedulerApp_2._0
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    
    public partial class EnterWindow : Window
    {
        public IUserRepository userRepository = new UserService();        

        public EnterWindow()
        {
            InitializeComponent();
        }
        // Отмена - возврат в главное окно
        private void СancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
        // Авторизация пользователя, открывает окно со списками
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            // Проверка логина и пароля
            if (userRepository.FindByName(login) != null)
            {
                if (userRepository.FindByName(login).Password == password)
                {
                    ToDoListsWindow toDoListsWindow = new(login);                    
                    toDoListsWindow.Show();
                    Close();
                } else
                {
                    MessageBox.Show("Неверный пароль");
                }
            } else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
