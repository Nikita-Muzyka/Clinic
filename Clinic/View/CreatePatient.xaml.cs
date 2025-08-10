using Azure;
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
using Clinic.ClinicPersonal;
using Clinic.Doctor;
using Microsoft.VisualBasic;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Page
    {
        PatientValidation patientValid = new PatientValidation();
        private Dictionary<string, string> errors;

        public CreatePatient()
        {
            InitializeComponent();
            DataContext = new CreatePatient_VM();
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            ErrorsClear(errors);
            errors = patientValid.Validation(firstNameBox.Text,
                lastNameBox.Text,
                patronymicBox.Text,
                phoneBox.Text,
                emailBox.Text,
                weightBox.Text,
                genderBox.Text,
                datebirthBox.Text);
            ErrorsCheck();
        }

        void ErrorsCheck()
        {
            if (errors.Count > 0)
            {
                ShowErrors(errors);
                MessageBox.Show("Исправте ошибки");
            }
            else
            {
                SavePatient();
            }
        }

        void ShowErrors(Dictionary<string, string> errors)
        {
            foreach (var err in errors)
            {
                var control = this.FindName(err.Key) as Control;
                if(control != null)
                {
                    control.BorderBrush = new SolidColorBrush(Colors.Red);
                    control.ToolTip = err.Value;
                }
            }
        }

        void ErrorsClear(Dictionary<string, string> errors)
        {
            if (errors == null)
            {

            }
            else
            {
                foreach (var err in errors)
                {
                    var control = this.FindName(err.Key) as Control;
                    if (control != null)
                    {
                        control.BorderBrush = new SolidColorBrush(Colors.Green);
                        control.ToolTip = "";
                    }
                }
            }
        }

        void SavePatient()
        {
            string DateFormatNow = DateTime.Now.ToShortDateString();
            Patient patient = new Patient
            {
                FirstName = firstNameBox.Text,
                LastName = lastNameBox.Text,
                Patronymic = patronymicBox.Text,
                DateBrith = datebirthBox.Text,
                Gender = genderBox.Text,
                Weight = int.Parse(weightBox.Text),
                Phone = phoneBox.Text,
                Email = emailBox.Text,
                Diagnosis = diagnosisBox.Text,
                YearsCreate = DateFormatNow,
                Place = placeBox.Text,
            };

            using (ClinicContext db = new ClinicContext())
            {
                db.Add(patient);
                db.SaveChanges();
            }
            MessageBox.Show("Пациент создан");
        }

    }
}
