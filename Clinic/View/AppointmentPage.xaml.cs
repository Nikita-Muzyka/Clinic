using Clinic.ClinicPersonal.Appointment;
using Clinic.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Clinic.Pages.AppointmentPage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        Patient patient;
        Worker worker;
        AppointmentValidation validation;
        ObservableCollection<TimeSlot> timeSlotsCollection = new ObservableCollection<TimeSlot>();
        string CheckTime;
        DateTime DateBrith;
        delegate void LoadDateDel();
        LoadDateDel loadDt;

      
        public AppointmentPage()
        {
            InitializeComponent();
            DataContext = new AppointmentPage_VM();
        }


        private void GenerateTime()
        {
            TimeSpan Start = new TimeSpan(8,0,0);
            TimeSpan End = new TimeSpan(20,0,0);
            TimeSpan Interval = TimeSpan.FromMinutes(30);
            for(TimeSpan time = Start;time <= End;time = time.Add(Interval))
            {
                timeSlotsCollection.Add(new TimeSlot
                {
                    Time = time.ToString(@"hh\:mm")
                });
            }
            timeListBox.ItemsSource = timeSlotsCollection;
        }

        void LoadDate()
        {
            if (patient != null && worker != null)
            {
                gridDate.Visibility = Visibility.Visible;
            }

        }

        private void CreateApp(object sender, RoutedEventArgs e)
        {
            validation = new AppointmentValidation();
            validation.ValidationApp(patient, worker,datebirthBox.Text,CheckTime);
        }

        private void datebirthBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerateTime();
        }

        private void timeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var timeSlot = timeListBox.SelectedItem as TimeSlot;
            CheckTime = timeSlot.Time;
        }
    }
}
