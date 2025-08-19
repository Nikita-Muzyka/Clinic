using Clinic.Doctor;
using Clinic.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       

        public ListPatientPage()
        {
            InitializeComponent();
            DataContext = new ListPatient_VM();
        }

        
        //private void DeletePatient_btn(object sender, RoutedEventArgs e)
        //{
        //    personChange = patientListBox.SelectedItem as Patient;

        //    var result = MessageBox.Show($"Удалить пациента {personChange.LastName}?",
        //                              "Подтверждение",
        //                              MessageBoxButton.YesNo,
        //                              MessageBoxImage.Question);
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        using (var db = new ClinicContext())
        //        {
        //            var dbPatient = db.Patients.Find(personChange.Id);
        //            db.Patients.Remove(dbPatient);
        //            db.SaveChanges();
        //        }
        //        patients.Remove(personChange);
        //    }

        //}
    }
}
