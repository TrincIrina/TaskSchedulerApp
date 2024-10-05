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
    /// Логика взаимодействия для DealsWindow.xaml
    /// </summary>
    public partial class DealsWindow : Window
    {        
        private readonly ITodoListRepository todoListRepository = new TodoService();
        private readonly IDealRepository dealRepository = new DealService();
        private int ToDoListId = 0;
        private string title = null!;
        private List<Deal> deals = new();
        public DealsWindow(string title)
        {
            InitializeComponent();

            ToDoListId = todoListRepository.GetByName(title).Id;
            ToDoListLabel.Content = title;
            deals = dealRepository.ListAllByToDoList(title);

            List<Deal> dealList = new List<Deal>();
            foreach (var deal in deals)
            {
                dealList.Add(deal);
            }

            DealsGrid.ItemsSource = dealList;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CompletDealButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
