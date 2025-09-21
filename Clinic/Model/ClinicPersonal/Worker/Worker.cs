using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Worker : ClinicPerson,IWorker,INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;
        private string? _patronymic;
        private string _gender;
        private string _phone;
        private string _email;
        private DateTime _date;
        private string? _place;
        private DateTime _yearsCreate;
        private string _salary;
        private ClinicRole _role;
        private int _infoRegId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public override string FirstName
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }
        public override string LastName
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }
        public override string? Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }
        public override DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public override string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
        public override string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }
        public override string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public override string? Place
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged();
            }
        }
        public override DateTime YearsCreate 
        {
            get => _yearsCreate;
            set
            {
                _yearsCreate = value;
                OnPropertyChanged();
            }
        } // год создания
        public string Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }
        public ClinicRole Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged();
            }
        }
        public int infoRegId
        {
            get => _infoRegId;
            set
            {
                _infoRegId = value;
                OnPropertyChanged();
            }
        }
        public PeopleRegistration infoReg { get; set; }

        public Worker()
        {

        }
        public Worker(string firstname, string lastname, string? patronymic, 
            DateTime date, string gender, string phone, 
            string email, string? place, string salary,
            ClinicRole role,string login,string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Patronymic = patronymic;
            Date = date;
            Gender = gender;
            Phone = phone;
            Email = email;
            Place = place;
            Salary = salary;
            Role = role;
            infoReg = new PeopleRegistration
            {
                Login = login,
                Password = password
            };
            YearsCreate = DateTime.Now;
        }

        public string CheckRoleName()
        {
            ClinicRole Role = this.Role;
            string RoleReturn = "";
            switch (Role)
            {
                case ClinicRole.HDoctor:
                    RoleReturn = "Глав.Врач";
                    break;
                case ClinicRole.MDoctor:
                    RoleReturn = "Зам.Глав.Врача";
                    break;
                case ClinicRole.LDoctor:
                    RoleReturn = "Зав.Отделения";
                    break;
                case ClinicRole.Doctor:
                    RoleReturn = "Доктор";
                    break;
                case ClinicRole.Register:
                    RoleReturn = "Регистратура";
                    break;
                case ClinicRole.Nurse:
                    RoleReturn = "Мед.Сестра";
                    break;
            }
            return RoleReturn;
        }

             public ClinicRole CheckedRole()
        {
            return _role;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
