using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly string UserLogin = string.Empty;
        private readonly string title = string.Empty;
        private readonly int ToDoListId;
        private List<Deal> deals = [];
        public DealsWindow(int todoListId, string login)
        {
            InitializeComponent();
            // сохранить логин пользователя: нужен чтобы вернуться на главную страницу
            UserLogin = login;
            // получить Id списка
            ToDoListId = todoListId;
            // сохранить название списка
            title = todoListRepository.GetById(todoListId).Title;
            // вывести заголовок (название списка дел)
            ToDoListLabel.Content = title;
            // вывести список дел                                             
            ListAllDeals();   
        }
        // добавить дело в список (открыть дополнительное окно)
        private void AddDealButton_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow addDealWindow = new(ToDoListId);            
            addDealWindow.ShowDialog();            
            // обновить список дел
            ListAllDeals();
        }
        // удалить дело из списка
        private void DeleteDealButton_Click(object sender, RoutedEventArgs e)
        {
            Deal deal = (Deal)DealsGrid.SelectedItem;
            if (deal != null)
            {
                dealRepository.DeleteById(deal.Id);
                DealsGrid.Items.Remove(deal);
            } else
            {
                MessageBox.Show("Выберите дело для удаления");
            }
        }
        // редактировать дело (открыть дополнительное окно)
        private void EditDealButton_Click(object sender, RoutedEventArgs e)
        {
            EditDealWindow editDealWindow = new((Deal)DealsGrid.SelectedItem);           
            editDealWindow.ShowDialog();            
            // обновить список дел
            ListAllDeals();
        }
        // завершить дело
        //private void CompletDealButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Deal deal = (Deal)DealsGrid.SelectedItem;
        //    if (deal != null)
        //    {
        //        dealRepository.IsDoneDeals(deal.Id);
        //        //DealsGrid.DataGridCheckBoxColumn= true;
        //        DealsGrid.Items.Refresh();
        //    } else
        //    {
        //        MessageBox.Show("Выберите дело для завершения");
        //    }
        //}
        // открыть дело (чек-лист)
        private void OpenDealButton_Click(object sender, RoutedEventArgs e)
        {
            Deal? deal = (Deal)DealsGrid.SelectedItem;
            if (deal == null)
            {
                MessageBox.Show("Выберите дело для открытия");
            }
            ItemsWindow itemsWindow = new(deal.Name, deal.Id);
            this.Hide();
            itemsWindow.ShowDialog();
            this.Show();            
        }
        // закрыть окно списка дел, открыть окно со списками
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoListsWindow toDoListsWindow = new(UserLogin);
            toDoListsWindow.Show();
            Close();
        }
        // вспомогательный метод - обновление списка дел
        private void ListAllDeals()
        {
            DealsGrid.Items.Clear();
            // получить список дел
            deals = dealRepository.ListAllByToDoList(title);
            // вывести список дел
            foreach (var deal in deals)
            {
                DealsGrid.Items.Add(deal);
            }
            //ICollectionView cvDeals = CollectionViewSource.GetDefaultView(DealsGrid.ItemsSource);
            
        }

        private void DayDealsMenu_Click(object sender, RoutedEventArgs e)
        {
            DealsGrid.Items.Clear();
            deals = dealRepository.ListAllByToDoList(title);
            List<Deal> dayDeals = [];
            DateTime now = DateTime.Now;            
            foreach (var deal in deals)
            {
                if (deal.Deadline.Day == now.Day)
                {
                    dayDeals.Add(deal);
                }
            }
            foreach (var deal in dayDeals)
            {
                DealsGrid.Items.Add(deal);
            }
        }

        private void WeekDealsMenu_Click(object sender, RoutedEventArgs e)
        {
            DealsGrid.Items.Clear();
            deals = dealRepository.ListAllByToDoList(title);
            List<Deal> weekDeals = [];
            DateTime now = DateTime.Now;
            DateTime week = now.AddDays(7);
            foreach (var deal in deals)
            {
                if (deal.Deadline <= week)
                {
                    weekDeals.Add(deal);
                }
            }
            foreach (var deal in weekDeals)
            {
                DealsGrid.Items.Add(deal);
            }
        }

        private void MonthDealsMenu_Click(object sender, RoutedEventArgs e)
        {
            DealsGrid.Items.Clear();
            deals = dealRepository.ListAllByToDoList(title);
            List<Deal> monthDeals = [];
            DateTime now = DateTime.Now;
            DateTime month = now.AddMonths(1);
            foreach (var deal in deals)
            {
                if (deal.Deadline <= month)
                {
                    monthDeals.Add(deal);
                }
            }
            foreach (var deal in monthDeals)
            {
                DealsGrid.Items.Add(deal);
            }
        }

        private void AllDealsMenu_Click(object sender, RoutedEventArgs e)
        {
            ListAllDeals();
        }
    }
}
