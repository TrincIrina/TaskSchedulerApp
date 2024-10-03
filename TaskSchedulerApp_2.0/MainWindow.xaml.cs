using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskSchedulerApp_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите закрыть приложение?",
                "Exit",
                MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {                
                Close();
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            EnterWindow enterWindow = new EnterWindow();
            this.Hide();
            enterWindow.ShowDialog();
            this.Show();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            this.Hide();
            registrationWindow.ShowDialog();
            this.Show();
        }
    }
}