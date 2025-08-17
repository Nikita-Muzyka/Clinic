using Clinic.ClinicPersonal;
using Clinic.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Clinic
{
    class CreatePatient_VM : INotifyPropertyChanged
    {

        ObservableCollection<Brush> _brushCollection = new ObservableCollection<Brush>();
        ObservableCollection<string> _toolTipCollection = new ObservableCollection<string>();
        ObservableCollection<string> _genderCollection = new()
        {
            "Мужской",
            "Женский"
        };
        Patient _patient;
        PatientValidation patientValidation { get; }
        public ICommand CreatePatientCommand { get; }

        bool CheckValidation = false;

        string? _firstName;
        string? _lastName;
        string? _patronymic;
        string? _gender;
        string? _phone;
        string? _email;
        string? _dateFree;
        DateTime? date;
        string? _place;
        string? _yearsCreate;
        string? _diagnosis;
        string? _weight;

        public ObservableCollection<Brush> BrushCollection
        {
            get => _brushCollection;
            set
            {
                _brushCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> ToolTipCollection
        {
            get => _toolTipCollection;
            set
            {
                _toolTipCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> GenderCollection
        {
            get => _genderCollection;
            set
            {
                _genderCollection = value;
                OnPropertyChanged();
            }
        }

        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string? Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }
        public string? DateFree
        {
            get => _dateFree;
            set
            {
                _dateFree = value;
                OnPropertyChanged();
            }
        }
        public string? Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
        public string? Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string? Place
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged();
            }
        }
        public string? Diagnosis
        {
            get => _diagnosis;
            set
            {
                _diagnosis = value;
                OnPropertyChanged();
            }
        }
        public string? Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }


        public CreatePatient_VM()
        {
            CreatePatientCommand = new RelayCommand(command2);
            patientValidation = new PatientValidation(BrushCollection, ToolTipCollection);
        }

        private void command2()
        {
            _patient = patientValidation.Validation(FirstName, LastName, Patronymic, DateFree, Gender, Weight, Phone, Email, Place, Diagnosis);
            bool resultCreatePatient = CreatePatient();
            MessageBox.Show(resultCreatePatient ? "Пациент Создан" : "Пациент не создан исправте ошибки");
        }
       
        private bool CreatePatient()
        {
            bool result = false;
            if (_patient is not null)
            {
                using (var db = new ClinicContext())
                {
                    try
                    {
                        db.Patients.Add(_patient);
                        db.SaveChanges();
                        result = true;
                                            }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
