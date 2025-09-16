using Clinic.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Clinic
{
    internal class CreateWorkerPage_VM : INotifyPropertyChanged
    {
        ObservableCollection<Brush> _brushCollection = new ObservableCollection<Brush>();
        ObservableCollection<string> _toolTipCollection = new ObservableCollection<string>();
        ObservableCollection<string> _genderCollection = new()
        {
            "Мужской",
            "Женский"
        };
        Worker _worker;
        WorkerValidation workerValidation { get; }
        public ICommand CreateWorkerCommand { get; }


        bool CheckHappen = false;
        int saveIdWorker;
        string? _firstName;
        string? _lastName;
        string? _patronymic;
        DateTime _date = DateTime.Now;
        string? _gender;
        string? _phone;
        string? _email;
        string? _place;
        string? _salary;
        string? _role;
        string? _yearsCreate;
        string? _login;
        string? _password;

        string _buttonText = "Создать";

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
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
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
        public string? Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }
        public string? Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged();
            }
        }
        public string? Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }

        public CreateWorkerPage_VM()
        {
            CreateWorkerCommand = new RelayCommand(CreateWorker);
            workerValidation = new WorkerValidation(BrushCollection, ToolTipCollection);
            CopyDatePatient();
        }
        private async void CreateWorker()
        {
            _worker = workerValidation.Validation(FirstName, LastName, Patronymic, Date, Gender, Phone, Email, Place, Salary, Role, Login, Password);
            await CreatePatientAsync();

        }
        private async Task CreatePatientAsync()
        {
            if (_worker is not null)
            {
                if (CheckHappen is true)
                {
                    using (var db = new ClinicContext())
                    {
                        try
                        {
                            var worker = await db.Workers.FindAsync(saveIdWorker);

                            if (worker != null)
                            {
                                // Обновляем данные
                                worker.FirstName = _worker.FirstName;
                                worker.LastName = _worker.LastName;
                                worker.Patronymic = _worker.Patronymic;
                                worker.Date = _worker.Date;
                                worker.Gender = _worker.Gender;
                                worker.Phone = _worker.Phone;
                                worker.Email = _worker.Email;
                                worker.Place = _worker.Place;
                                worker.Salary = _worker.Salary;
                                worker.Role = _worker.Role;
                                worker.infoReg.Login = _worker.infoReg.Login;
                                worker.infoReg.Password = _worker.infoReg.Password;
                                // Сохраняем изменения
                                await db.SaveChangesAsync();
                                MessageBox.Show("Работник изменен");
                            }
                            else
                            {
                                MessageBox.Show("Работник не изменен");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    using (var db = new ClinicContext())
                    {
                        try
                        {
                            await db.Workers.AddAsync(_worker);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Работник создан");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        void CopyDateWorker()
        {
            if (Database.Instance.Worker is not null)
            {
                _worker = Database.Instance.Worker;
                saveIdWorker = _worker.Id;
                FirstName = _worker.FirstName;
                LastName = _worker.LastName;
                Patronymic = _worker.Patronymic;
                Date = _worker.Date;
                Gender = _worker.Gender;
                Phone = _worker.Phone;
                Email = _worker.Email;
                Place = _worker.Place;
                Role = _worker.Role;
                Place = _worker.infoReg.Login;
                Place = _worker.infoReg.Password;



                Database.Instance.Patient = null;
                ButtonText = "Изменить";
                CheckHappen = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
