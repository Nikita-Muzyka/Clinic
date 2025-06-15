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
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            Patient patient = createPatient();
            ErrorsClear(errors);
            errors = patientValid.Validation(patient);
            ErrorsCheck(patient);
        }

        Patient createPatient()
        {
            return new Patient
            {
                FirstName = firstNameBox.Text,
                LastName = lastNameBox.Text,
                Patronymic = patronymicBox.Text,
                DateBrith = byte.Parse(datebrithBox.Text),
                Gender = boxGender.Text,
                Weight = weightBox.Text,
                Contact = contactBox.Text,
                Diagnosis = diagnosisBox.Text,
            };
        }

        void ErrorsCheck(Patient patient)
        {
            if (errors.Count > 0)
            {
                ShowErrors(errors);
                MessageBox.Show("Исправте ошибки");
            }
            else
            {
                SavePatient(patient);
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
            if (errors != null ||errors.Count > 0)
            {
                foreach (var err in errors)
                {
                    var control = this.FindName(err.Key) as Control;
                    if (control != null)
                    {
                        firstNameBox.ClearValue(Control.BorderBrushProperty);
                    }
                }
            }
        }

        void SavePatient(Patient patient)
        {
            //using (ClinicContext db = new ClinicContext())
            //{
            //    db.Add(patient);
            //    db.SaveChanges();
            //}
            MessageBox.Show("Пациент создан");
        }
    }
}
