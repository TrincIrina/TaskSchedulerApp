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
using TaskSchedulerApp.Repository;

namespace TaskSchedulerApp_2._0
{
    /// <summary>
    /// Логика взаимодействия для AddEditDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        private readonly IDealRepository dealRepository = new DealService();
        private int ToDoListId;
        public AddDealWindow(int todoListId)
        {
            InitializeComponent();

            ToDoListId = todoListId;
        }
    }
}
