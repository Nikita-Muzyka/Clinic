using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public override DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
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
        public PeopleRegistration infoReg { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ClinicRole CheckedRole()
        {
            return _role;
        }

    }
}
