using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Clinic
{
    internal class Patient : ClinicPerson, IPatient, INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string? _patronymic;
        private string _gender;
        private string _contact;
        private string _dateBrith;
        private string? _place;
        private string _yearsCreate;
        private string? _diagnosis;
        private int _weight;

        public override int Id { get; set; }

        public override string FirstName
        {
            get => _firstName;
            set => SetField(ref _firstName, value);
        }

        public override string LastName
        {
            get => _lastName;
            set => SetField(ref _lastName, value);
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
            get => _dateBrith;
            set => SetField(ref _dateBrith, value);
        }

        public override string? Place
        {
            get => _place;
            set => SetField(ref _place, value);
        }

        public override string YearsCreate
        {
            get => _yearsCreate;
            set => SetField(ref _yearsCreate, value);
        }

        public string Diagnosis
        {
            get => _diagnosis;
            set => SetField(ref _diagnosis, value);
        }

        public int Weight
        {
            get => _weight;
            set => SetField(ref _weight, value);
        }

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