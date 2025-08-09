using Clinic.Model.FrameServise;
using Clinic.Pages;
using Clinic.View;
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
    internal class MainWindow_VM : INotifyPropertyChanged
    {
        string _welcomeNameText;
        public string WelcomeNameText
        {
            get => _welcomeNameText;
            set
            {
                _welcomeNameText = value;
                OnPropertyChanged();
            }
        }
        FrameServise _frameServise;
        public ICommand StatisticsCommand { get; }
        public ICommand RegistrationPatientCommand { get; }
        public ICommand Close {  get; }
        public ICommand Reveal { get; }
        public ICommand Hide { get; }
        public MainWindow_VM(Frame Frame)
        {
            Worker work = new Worker
            {
                FirstName = "Admin",
                Role = ClinicRole.Admin
            };
            Database.Instance.Worker = work;

            _frameServise = new FrameServise(Frame);
            StatisticsCommand = new RelayCommand(StatisticsNavigateTo);
            RegistrationPatientCommand = new RelayCommand(RegistrationPatientTo);

            Close = new RelayCommand(CloseApp);
            Reveal = new RelayCommand(RevealApp);
            Hide = new RelayCommand(HideApp);

            WelcomeNameText = Database.Instance.Worker.FirstName;

        }
        
        private void StatisticsNavigateTo() => _frameServise.NavigateTo<StatisticsPage>();
        private void RegistrationPatientTo() => _frameServise.NavigateTo<RegistrationPage>();
        private void CloseApp() => Application.Current.MainWindow.Close();
        private void RevealApp() => Application.Current.MainWindow.WindowState = 
            Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        private void HideApp() => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
