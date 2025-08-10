using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Clinic
{
    class CreatePatient_VM : INotifyPropertyChanged
    {
        public ICommand CreatePatient { get; }
        string _firstName;
        string _lastName;
        string? _patronymic;
        string _gender;
        string _phone;
        string _email;
        string _dateBrith;
        string? _place;
        string _yearsCreate;
        string _diagnosis;
        string _weight;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public CreatePatient_VM()
        {
            CreatePatient = new RelayCommand(command2);
        }

        private void command2()
        {
            MessageBox.Show(FirstName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
