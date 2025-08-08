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
using Clinic.Pages;

namespace Clinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Worker work = new Worker
            {   
                FirstName = "Admin",
                Role = ClinicRole.Admin
            };
            Database.Instance.Worker = work;

            DataContext = new MainWindow_VM(MainFrame);
        }


        private void RegistrationPage_Button(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage());
        }

        private void ClinicPersonal_Button(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClinicPersonalPage());
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}