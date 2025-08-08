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
    /// Логика взаимодействия для ClinicPersonalPage.xaml
    /// </summary>
    public partial class ClinicPersonalPage : Page
    {
        CreateWorkerPage createWorker = new CreateWorkerPage();
        WorkersListPage listWorkers = new WorkersListPage();
        public ClinicPersonalPage()
        {
            InitializeComponent();
        }

        private void CreateWorker_btn(object sender, RoutedEventArgs e)
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.MDoctor) PersonFrame.Navigate(createWorker);
            else MessageBox.Show("Недостаточный уровень доступа");
        }

        private void ListWorkers_btn(object sender, RoutedEventArgs e)
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.Nurse) PersonFrame.Navigate(listWorkers);
            else MessageBox.Show("Недостаточный уровень доступа");
        }
    }
}
