using Clinic.Doctor;
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
            LoadPeople();
        }

        private void LoadPeople()
        {
            using (var db = new ClinicContext())
            {
                var patients = db.Patients.ToList();
                patientList.ItemsSource = patients;
                var workers = db.Workers.ToList();
                workerList.ItemsSource = workers;
            }
        }
    }
}
