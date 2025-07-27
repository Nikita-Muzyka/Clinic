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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public AppointmentPage()
        {
            InitializeComponent();
        }

        private void CreateAppointment_Button(object sender, RoutedEventArgs e)
        {
            int countApp = Database.Instance.Appos.Count;
            countApp++;
            Appointment app = new Appointment
            {
                Id = countApp,
                // добавление класса воркер в апп
                // пациент добавление
                Date = DateTime.Parse(dateApp.Text)
            };
            Database.Instance.Appos.Add(app);
            MessageBox.Show("++");
            string custom3 = app.Date.ToString(" dd MM yyyy HH:mm"); 
            MessageBox.Show(custom3);
        }
    }
}
