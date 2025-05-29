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
        private bool registration = false;

        private Registration regWindow = new Registration();
        private ClinicPerson worker;

        public MainWindow()
        {
            InitializeComponent();
            //regWindow.MyEvent += ChangeReg;
            //regWindow.ShowDialog();
            //CheckReg();
            //main = new MainPage(worker);
            worker = new Worker
            {
                Id = 1,
                Age = 25,
                FirstName = "Dima",
                LastName = "tIMOFEEV",
                Gender = "Male",
            };
            Database.Instance.Workers.Add(worker);
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
                Workers = worker,
                Patients = pat,
            };
            Database.Instance.Appos.Add(ap);
        }

        void CheckReg()
        {
            if (registration == false)
            {
                this.Close();
            }
        }

        void ChangeReg()
        {
            registration = true;
            worker = regWindow.work;
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
    }
}