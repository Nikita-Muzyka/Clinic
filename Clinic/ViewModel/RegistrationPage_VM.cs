using Clinic.Model.FrameServise;
using Clinic.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic
{
    class RegistrationPage_VM
    {
        FrameServise frameServise;
        public ICommand CreatePatientCommand { get; }
        public RegistrationPage_VM(Frame _frame)
        {
            frameServise = new FrameServise(_frame);
            CreatePatientCommand = new RelayCommand(CreatePatientTo);
        }
        private void CreatePatientTo() => frameServise.NavigateTo<CreatePatient>();
    }
}
