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
    /// Логика взаимодействия для ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        private readonly IItemRepository itemRepository = new ItemService(); 
        private List<Item> items = new List<Item>();
        private int DealId;
        public ItemsWindow(string dealName, int dealId)
        {
            InitializeComponent();

            GreetingLabel.Content = dealName;
            DealId = dealId;
            ListAllItems();
        }
        
        private void AddDealButton_Click(object sender, RoutedEventArgs e)
        {
            string description = DescriptionTextBox.Text;
            Item item = new Item()
            {
                Description = description,
                DealId = DealId
            };
            itemRepository.Add(item);
            ItemsGrid.Items.Add(item);
        }

        private void DeleteDealButton_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)ItemsGrid.SelectedItem;
            if (item != null)
            {
                itemRepository.DeleteById(item.Id);
                ItemsGrid.Items.Remove(item);
            }            
            else
            {
                MessageBox.Show("Выберите пункт для удаления");
            }
        }

        private void EditDealButton_Click(object sender, RoutedEventArgs e)
        {
            string description = DescriptionTextBox.Text;
            Item item = (Item)ItemsGrid.SelectedItem;
            if (item != null)
            {
                item.Description = description;
                itemRepository.Update(item);
            }
            else
            {
                MessageBox.Show("Выберите пункт для редактирования");
            }
            ListAllItems();
        }

        private void CompletDealButton_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)ItemsGrid.SelectedItem;
            if (item != null)
            {
                itemRepository.IsDoneItems(item.Id);
                ItemsGrid.Items.Refresh();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // Вспомогательный метод для обновления чек-листа
        private void ListAllItems()
        {
            ItemsGrid.Items.Clear();
            // получить список дел
            items = itemRepository.ListAllByDeal(DealId);
            // вывести список дел
            foreach (var item in items)
            {
                ItemsGrid.Items.Add(item);
            }
        }

    }
}
