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
        List<ClinicPerson> patientList = new List<ClinicPerson>();
        public ListPatientPage()
        {
            InitializeComponent();
            int countPatient = Database.Instance.Patients.Count;
            patientList = Database.Instance.Patients;
            PatientListBox.ItemsSource = patientList;
        }
    }
}
