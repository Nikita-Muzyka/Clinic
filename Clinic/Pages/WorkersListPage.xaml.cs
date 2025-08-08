using Clinic.Doctor;
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
    /// Логика взаимодействия для WorkersListPage.xaml
    /// </summary>
    public partial class WorkersListPage : Page
    {
        ObservableCollection<Worker> workers;
        Worker workerDel;
        ObservableCollection<ClinicRole> roleWorker;
        ClinicRole role = new ClinicRole();
        public WorkersListPage()
        {
            InitializeComponent();
            LoadWorkers();
        }

        void LoadWorkers()
        {
            using (var db = new ClinicContext())
            {
                var Dbworkers = db.Workers.ToList();
                workers = new ObservableCollection<Worker>(Dbworkers);
            }
            workersListBox.ItemsSource = workers;
        }
        
        void SetRole()
        {
            var workerNow = workersListBox.SelectedItem as Worker;
            role = workerNow.Role;
            int numberRole = (int)role;
            roleBox.ItemsSource = Enum.GetValues(typeof(ClinicRole));
            roleBox.SelectedIndex = numberRole;
        }

        private void workersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.MDoctor) 
            {
                infoWorkers.Visibility = Visibility.Visible;
                SetRole(); 
            }
        }

        private void SaveWorker_btn(object sender, RoutedEventArgs e)
        {
            int numberRole = roleBox.SelectedIndex;
            role = (ClinicRole)numberRole;
            var workerChoose = workersListBox.SelectedItem as Worker;
            using (var db = new ClinicContext())
            {
                var dbworkers = db.Workers.Find(workerChoose.Id);
                if(dbworkers != null)
                {
                    dbworkers.FirstName = firstNameBox.Text;
                    dbworkers.LastName = lastNameBox.Text;
                    dbworkers.Patronymic = patronymicBox.Text;
                    dbworkers.Gender = genderBox.Text;
                    dbworkers.DateBrith = dateBrithBox.Text;
                    dbworkers.Phone = phoneBox.Text;
                    dbworkers.Email = emailBox.Text;
                    dbworkers.Place = placeBox.Text;
                    dbworkers.Salary = salaryBox.Text;
                    dbworkers.Role = role;
                };
                db.SaveChanges();
            }
        }

        private void DeleteWorker_btn(object sender, RoutedEventArgs e)
        {
            workerDel = workersListBox.SelectedItem as Worker;

            var result = MessageBox.Show($"Удалить пациента {workerDel.LastName}?",
                                      "Подтверждение",
                                      MessageBoxButton.YesNo,
                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ClinicContext())
                {
                    var dbPatient = db.Patients.Find(workerDel.Id);
                    db.Patients.Remove(dbPatient);
                    db.SaveChanges();
                }
                workers.Remove(workerDel);
            }

        }
    }
}
