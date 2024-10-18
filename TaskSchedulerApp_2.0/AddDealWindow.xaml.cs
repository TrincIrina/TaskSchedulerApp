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
    /// Логика взаимодействия для AddEditDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        private readonly IDealRepository dealRepository = new DealService();
        // todoListId - идентификатор списка
        private int ToDoListId;
        public AddDealWindow(int todoListId)
        {
            InitializeComponent();

            ToDoListId = todoListId;
        }

        private void СancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Deal deal = new Deal()
            {
                Name = NameTextBox.Text,
                Priority = Convert.ToInt32(PriorityTextBox.Text),
                DateCreation = DateTime.Now,
                Deadline = (DateTime)DeadlainCalendar.SelectedDate,
                ToDoListId = ToDoListId
            };
            dealRepository.Add(deal);
            Close();
        }
    }
}
