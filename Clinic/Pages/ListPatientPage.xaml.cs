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

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPatientPage.xaml
    /// </summary>
    public partial class ListPatientPage : Page
    {
        ClinicPerson personChange;
        
        public ListPatientPage()
        {
            InitializeComponent();
            LoadPatient();
        }

        void LoadPatient()
        {
            using (var db = new ClinicContext())
            {
                var Patients = db.Patients.ToList();
                patientListBox.ItemsSource = Patients;
            }
        }

        private void SavePatientChange_btn(object sender, RoutedEventArgs e)
        {
            personChange = patientListBox.SelectedItem as ClinicPerson;
            using (var db = new ClinicContext())
            {
                var dbPatient = db.Patients.Find(personChange.Id);

                dbPatient.FirstName = firstNameBox.Text;
                dbPatient.LastName = lastNameBox.Text;
                dbPatient.Patronymic = patronymicBox.Text;
                dbPatient.Gender = genderBox.Text;
                dbPatient.Contact = contactBox.Text;
                dbPatient.DateBrith = dateBrithBox.Text;
                dbPatient.Place = placeBox.Text;
                dbPatient.Diagnosis = diagnosisBox.Text;

                db.SaveChanges();
            }
            LoadPatient();
        }

        private void patientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            infoPatient.Visibility = Visibility.Visible;
        }

        private void DeletePatient_btn(object sender, RoutedEventArgs e)
        {
            personChange = patientListBox.SelectedItem as ClinicPerson;

            var result = MessageBox.Show($"Удалить пациента {personChange.LastName}?",
                                      "Подтверждение",
                                      MessageBoxButton.YesNo,
                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ClinicContext())
                {
                    var dbPatient = db.Patients.Find(personChange.Id);
                    db.Patients.Remove(dbPatient);
                    db.SaveChanges();
                }
                LoadPatient();
            }

        }
    }
}
