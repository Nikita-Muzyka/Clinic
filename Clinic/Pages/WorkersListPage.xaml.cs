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

        private void workersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Database.Instance.Worker.CheckedRole() >= ClinicRole.MDoctor)
                infoWorkers.Visibility = Visibility.Visible;
        }

        private void SaveWorker_btn(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteWorker_btn(object sender, RoutedEventArgs e)
        {

        }
    }
}
