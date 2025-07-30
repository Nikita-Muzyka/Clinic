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
        Patient patient;
        Worker worker;
        AppointmentValidation validation;
        DateTime DateBrith;
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

        private void patientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient = patientList.SelectedItem as Patient;
        }

        private void workerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker = workerList.SelectedItem as Worker;
        }

        private void CreateApp(object sender, RoutedEventArgs e)
        {
            validation = new AppointmentValidation();
            validation.ValidationApp(patient, worker,datebirthBox.Text);
        }
    }
}
