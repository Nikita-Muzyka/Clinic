using Clinic.Model.FrameServise;
using Clinic.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic
{
    internal class ClinicPersonalPage_VM : INotifyPropertyChanged
    {
        FrameServise frameServise;
        public ICommand CreateWorkerCommand { get; }
        public ICommand ListWorkerCommand { get; }

        bool _checkedCreateWorkerButton;
        public bool CheckedCreateWorkerButton
        {
            get => _checkedCreateWorkerButton;
            set
            {
                _checkedCreateWorkerButton = value;
                OnPropertyChanged();
            }
        }

        public ClinicPersonalPage_VM(Frame _frame)
        {
            frameServise = new FrameServise(_frame);
            CreateWorkerCommand = new RelayCommand(CreateWorkerTo);
            ListWorkerCommand = new RelayCommand(ListWorkerTo);
            FrameServise.NavigateCreateWorker += CreateWorkerTo;
        }

        private void CreateWorkerTo()
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.MDoctor)
            {
                frameServise.NavigateTo<CreateWorkerPage>();
                CheckedCreateWorkerButton = true;
            }
        }
        private void ListWorkerTo()
        {
            if (Database.Instance.Worker.CheckedRole() >= ClinicRole.Register)
            {
                frameServise.NavigateTo<WorkersListPage>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
