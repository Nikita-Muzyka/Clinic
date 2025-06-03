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
        private ClinicPerson worker;

        public MainWindow()
        {
            InitializeComponent();
            Patient pat = new Patient
            {
                Id = 1,
                FirstName = "Nikita",
                LastName = "Vasiliv",
                Age = 12,
                Diagnosis = "Kardiologia"
            };
            Database.Instance.Patients.Add(pat);

            Appointment ap = new Appointment
            {
                Id = 1,
                Id_Workers = 1,
                Id_Patients = 1,
            };
            Database.Instance.Appos.Add(ap);
        }

        private void Main_RadioButton(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void Reception_RadioButton(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReceptionPage(worker));
        }

        private void RegistrationPage_Button(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage());
        }

        private void ClinicPersonal_Button(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClinicPersonalPage());
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}