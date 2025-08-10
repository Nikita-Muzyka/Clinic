using Clinic.Model.FrameServise;
using Clinic.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic
{
    class RegistrationPage_VM
    {
        FrameServise frameServise;
        public ICommand CreatePatientCommand { get; }
        public ICommand ListPatientCommand { get; }
        public RegistrationPage_VM(Frame _frame)
        {
            frameServise = new FrameServise(_frame);
            CreatePatientCommand = new RelayCommand(CreatePatientTo);
            ListPatientCommand = new RelayCommand(ListPatientTo);
        }
        private void CreatePatientTo()
        {
            if(Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<CreatePatient>();
            }
        }
        private void ListPatientTo()
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<ListPatientPage>();
            }
        }
    }
}
