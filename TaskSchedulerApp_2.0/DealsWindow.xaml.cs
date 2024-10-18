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
        private string title = string.Empty;
        private int ToDoListId = 0;
        private string UserLogin = string.Empty;
        private List<Deal> deals = new();
        public DealsWindow(string t, string login)
        {
            InitializeComponent();
            // сохранить логин пользователя: нужен чтобы вернуться на главную страницу
            UserLogin = login;
            // сохранить название списка
            title = t;

            ToDoListId = todoListRepository.GetByName(title).Id; // получить Id списка
            ToDoListLabel.Content = title;                       // вывести заголовок
                                                                 // (название списка дел)
            ListAllDeals();   // вывести список дел
        }
        // добавить дело в список (открыть дополнительное окно)
        private void AddDealButton_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow addDealWindow = new AddDealWindow(ToDoListId);
            //this.Hide();
            addDealWindow.ShowDialog();
            //this.Show();
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
            EditDealWindow editDealWindow = new EditDealWindow((Deal)DealsGrid.SelectedItem);
            //this.Hide();
            editDealWindow.ShowDialog();
            //this.Show();
            // обновить список дел
            ListAllDeals();
        }
        // завершить дело
        private void CompletDealButton_Click(object sender, RoutedEventArgs e)
        {
            Deal deal = (Deal)DealsGrid.SelectedItem;
            if (deal != null)
            {
                dealRepository.IsDoneDeals(deal.Id);
                //DealsGrid.DataGridCheckBoxColumn= true;
                DealsGrid.Items.Refresh();
            } else
            {
                MessageBox.Show("Выберите дело для завершения");
            }
        }
        // открыть дело (чек-лист)
        private void OpenDealButton_Click(object sender, RoutedEventArgs e)
        {
            Deal? deal = (Deal)DealsGrid.SelectedItem;
            if (deal == null)
            {
                MessageBox.Show("Выберите дело для открытия");
            }
            ItemsWindow itemsWindow = new ItemsWindow(deal.Name, deal.Id);
            this.Hide();
            itemsWindow.ShowDialog();
            this.Show();            
        }
        // закрыть окно списка дел, открыть окно со списками
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoListsWindow toDoListsWindow = new ToDoListsWindow(UserLogin);
            toDoListsWindow.Show();
            Close();
        }

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
        }

    }
}
