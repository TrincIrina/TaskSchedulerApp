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
        private List<Item> items = [];        
        private readonly int DealId;
        public ItemsWindow(string dealName, int dealId)
        {
            InitializeComponent();
            // вывод названия чек-листа
            GreetingLabel.Content = dealName;            
            DealId = dealId;
            // вывод чек-листа
            ListAllItems();
        }
        // добавить пункт
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string description = DescriptionTextBox.Text;
            Item item = new()
            {
                Description = description,
                DealId = DealId
            };
            itemRepository.Add(item);
            ItemsGrid.Items.Add(item);
        }
        // удалить пункт
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
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
        // редактировать пункт
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
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
        // завершить пункт
        //private void CompletItemButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Item item = (Item)ItemsGrid.SelectedItem;
        //    if (item != null)
        //    {
        //        itemRepository.IsDoneItems(item.Id);
        //        ItemsGrid.Items.Refresh();
        //    }
        //}
        // закрыть окна чек-листа
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
