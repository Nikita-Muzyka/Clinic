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
            LoadPeople();
        }

        private void LoadPeople()
        {
            using (var db = new ClinicContext())
            {
                var patients = db.Patients.ToList();
                patientList.ItemsSource = patients;
                var workers = db.Workers.ToList();
                workerList.ItemsSource = workers;
            }
            loadDt += LoadDate;

            //Worker worker = new Worker
            //{
            //    FirstName = "Dima",
            //    LastName = "Burov",
            //    Contact = "2232323",
            //    DateBrith = "11.11.11",
            //    Gender = "Myj",
            //    Place = "dadada",
            //    Title = "adadad",
            //    YearsCreate = "awdawd",
            //    Salary = "dwad",
            //    infoReg = new PeopleRegistration
            //    {
            //        Login = "11",
            //        Password = "11"
            //    }

            //};
            //using (var db = new ClinicContext())
            //{
            //    db.Add(worker);
            //    db.SaveChanges();
            //}

        }

        private void patientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient = patientList.SelectedItem as Patient;
            loadDt();
        }

        private void workerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            worker = workerList.SelectedItem as Worker;
            loadDt();

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
