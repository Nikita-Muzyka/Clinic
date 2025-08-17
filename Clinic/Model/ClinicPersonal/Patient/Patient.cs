using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Clinic
{
    internal class Patient : ClinicPerson, IPatient, INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string? _patronymic;
        private DateTime _date;
        private string _gender;
        private string _phone;
        private string _email;
        private string? _place;
        private DateTime _yearsCreate;
        private string? _diagnosis;
        private int _weight;

        public override int Id { get; set; }

        public override string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public override string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
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

        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        public Patient()
        {

        }
        public Patient(
            string firstName, string lastName, 
            string? patronymic, DateTime date,
            string gender, int weight,
            string phone, string email,  
            string? place, string? diagnosis
            )
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Gender = gender;
            Phone = phone;
            Email = email;
            Date = date;
            Place = place;
            YearsCreate = DateTime.Now;
            Diagnosis = diagnosis;
            Weight = weight;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}