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
            Print();
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
            CheckListBox.Items.Add(item);            
            DescriptionTextBox.Clear();
        }
        // удалить пункт
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            string description = CheckListBox.SelectedItem.ToString();
            if (CheckListBox.SelectedItem != null)
            {
                int id = 0;
                foreach (var item in items)
                {
                    if (item.Description == description)
                    {
                        id = item.Id;
                    }
                }
                itemRepository.DeleteById(id);
                CheckListBox.Items.Remove(CheckListBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите пункт для удаления");
            }
        }
        // редактировать пункт
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            string description = CheckListBox.SelectedItem.ToString();
            if (CheckListBox.SelectedItem != null)
            {                
                int id = 0;
                foreach (Item it in items)
                {
                    if (it.Description == description)
                    {
                        id = it.Id;
                    }
                }
                description = DescriptionTextBox.Text;
                Item item = new()
                {
                    Id = id,
                    Description = description,
                    DealId = DealId
                };
                itemRepository.Update(item);
                Print();
                DescriptionTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Выберите пункт для редактирования");
            }                   
        }        
        // закрыть окно чек-листа
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // впсомогательный метод - вывод чек-листа
        private void Print()
        {
            // вывод чек-листа
            CheckListBox.Items.Clear();
            // получить список дел
            items = itemRepository.ListAllByDeal(DealId);
            // вывести список дел
            foreach (var item in items)
            {
                CheckListBox.Items.Add(item);
            }
        }
    }
}
