using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Worker : ClinicPerson,IWorker
    {
        private string _firstname;
        private string _lastname;
        private string? _patronymic;
        private string _gender;
        private string _contact;
        private string _datebrith;
        private string _place;
        private string _yearsCreate;
        private string _salary;
        private ClinicRole _role;
        public override int Id { get; set; }
        public override string FirstName
        {
            get => _firstname;
            set => SetField(ref _firstname, value);
        }
        public override string LastName
        {
            get => _lastname;
            set => SetField(ref _lastname, value);
        }
        public override string? Patronymic
        {
            get => _patronymic;
            set => SetField(ref _patronymic, value);
        }
        public override string Gender
        {
            get => _gender;
            set => SetField(ref _gender, value);
        }
        public override string Contact
        {
            get => _contact;
            set => SetField(ref _contact, value);
        }
        public override string DateBrith
        {
            get => _datebrith;
            set => SetField(ref _datebrith, value);
        }
        public override string Place
        {
            get => _place;
            set => SetField(ref _place, value);
        }
        public override string YearsCreate { get; set; } // год создания
        public string Salary
        {
            get => _salary;
            set => SetField(ref _salary, value);
        }
        public ClinicRole Role
        {
            get => _role;
            set => SetField(ref _role, value);
        }
        public PeopleRegistration infoReg { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
