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
    /// Логика взаимодействия для EditDealWindow.xaml
    /// </summary>
    public partial class EditDealWindow : Window
    {
        private readonly IDealRepository dealRepository = new DealService();
        private readonly Deal deal = new();
        public EditDealWindow(Deal d)
        {
            InitializeComponent();

            deal = d;
            // заполнение полей из существующего дела
            NameTextBox.Text = deal.Name;
            PriorityTextBox.Text = Convert.ToString(deal.Priority);
            DeadlainCalendar.SelectedDate = deal.Deadline;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Deal updatedDeal = new()
            {
                Id = deal.Id,
                Name = NameTextBox.Text,
                Priority = Convert.ToInt32(PriorityTextBox.Text),
                DateCreation = deal.DateCreation,
                Deadline = (DateTime)DeadlainCalendar.SelectedDate,
                ToDoListId = deal.ToDoListId
            };
            dealRepository.Update(updatedDeal);
            Close();
        }

        private void СancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
