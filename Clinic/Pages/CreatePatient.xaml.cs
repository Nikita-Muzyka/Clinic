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
    /// Логика взаимодействия для CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Page
    {
        public CreatePatient()
        {
            InitializeComponent();
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            createPatient();
        }

        void createPatient()
        {
            int count = Database.Instance.Patients.Count;
            count++;
            Patient patient = new Patient
            {
                Id = count,
                FirstName = firstNameBox.Text,
                LastName = lastNameBox.Text,
                Patronymic = PatronymicBox.Text,
                Age = byte.Parse(AgeBox.Text),
                Gender = GenderBox.Text,
                Weight = WeightBox.Text,
                Contact = ContactBox.Text,
                Diagnosis = DiagnosisBox.Text
            };
            Database.Instance.Patients.Add(patient);
            MessageBox.Show("CREATE");
        }
    }
}
