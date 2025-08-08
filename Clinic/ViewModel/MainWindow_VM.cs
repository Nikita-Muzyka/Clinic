using Clinic.Model.FrameServise;
using Clinic.View;
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
    internal class MainWindow_VM
    {
        FrameServise _frameServise;
        public ICommand StatisticsCommand { get; }
        public ICommand Close {  get; }
        public ICommand Reveal { get; }
        public ICommand Hide { get; }
        public MainWindow_VM(Frame Frame)
        {
            _frameServise = new FrameServise(Frame);
            StatisticsCommand = new RelayCommand(StatisticsNavigateTo);
            Close = new RelayCommand(CloseApp);
            Reveal = new RelayCommand(RevealApp);
            Hide = new RelayCommand(HideApp);
        }
        
        private void StatisticsNavigateTo() => _frameServise.NavigateTo<StatisticsPage>();
        private void CloseApp() => Application.Current.MainWindow.Close();
        private void RevealApp() => Application.Current.MainWindow.WindowState = 
            Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        private void HideApp() => Application.Current.MainWindow.WindowState = WindowState.Minimized;

    }
}
