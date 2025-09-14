using Clinic.Model.FrameServise;
using Clinic.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic
{
    class RegistrationPage_VM : INotifyPropertyChanged
    {
        FrameServise frameServise;
        public ICommand CreatePatientCommand { get; }
        public ICommand ListPatientCommand { get; }
        public ICommand AppointmentCommand { get; }

        bool _checkedCreatePatientButton;
        public bool CheckedCreatePatientButton
        {
            get => _checkedCreatePatientButton;
            set
            {
                _checkedCreatePatientButton = value;
                OnPropertyChanged();
            }
        }

        public RegistrationPage_VM(Frame _frame)
        {
            frameServise = new FrameServise(_frame);
            CreatePatientCommand = new RelayCommand(CreatePatientTo);
            ListPatientCommand = new RelayCommand(ListPatientTo);
            AppointmentCommand = new RelayCommand(AppointmentTo);
            FrameServise.NavigateEvent += CreatePatientTo;
        }

        private void CreatePatientTo()
        {
            if(Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<CreatePatient>();
                CheckedCreatePatientButton = true;
            }
        }
        private void ListPatientTo()
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<ListPatientPage>();
            }
        }
        private void AppointmentTo()
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<AppointmentPage>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
