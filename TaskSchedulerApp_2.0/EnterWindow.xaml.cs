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
        public ITodoListRepository todoListRepository = new TodoService();
        public IDealRepository dealRepository = new DealService();
        public IItemRepository itemRepository = new ItemService();

        public EnterWindow()
        {
            InitializeComponent();
        }

        private void СancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
