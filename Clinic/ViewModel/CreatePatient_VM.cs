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
        DateTime _date = DateTime.Now;
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
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }


        public CreatePatient_VM()
        {
            CreatePatientCommand = new RelayCommand(CreatePatient);
            patientValidation = new PatientValidation(BrushCollection, ToolTipCollection);
        }

        private async void CreatePatient()
        {
            _patient = patientValidation.Validation(FirstName, LastName, Patronymic, Date, Gender, Weight, Phone, Email, Place, Diagnosis);
            await CreatePatientAsync();

        }
       
        private async Task CreatePatientAsync()
        {
            if (_patient is not null)
            {
                using (var db = new ClinicContext())
                {
                    try
                    {
                        await db.Patients.AddAsync(_patient);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Пациента создан");
                                            }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
