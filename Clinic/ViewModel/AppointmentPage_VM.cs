using Clinic.ClinicPersonal.Appointment;
using Clinic.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Clinic
{
    internal class AppointmentPage_VM : INotifyPropertyChanged
    {
        AppointmentValidation AppValidation { get; set; }
        public Patient SelectedPatient { get; set; }
        public Worker SelectedWorker { get; set; }

        ObservableCollection<TimeSlot> _timeSlotsCollection;
        public ObservableCollection<TimeSlot> TimeSlotsCollection
        {
            get => _timeSlotsCollection;
            set
            {
                _timeSlotsCollection = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Patient> _patients;
        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Worker> _workers;
        public ObservableCollection<Worker> Workers
        {
            get => _workers;
            set
            {
                _workers = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateAppointmentCommand { get; set; }

        DateTime _date = DateTime.Now;
        public TimeSlot SelectedTimeSlot { get; set; }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public AppointmentPage_VM()
        {
            LoadUsers();
            GenerateTime();
            CreateAppointmentCommand = new RelayCommand(CreateAppointment);
        }

        async void LoadUsers()
        {
            await LoadClinicUsersAsync();
        }
        async Task LoadClinicUsersAsync()
        {
            using (var db = new ClinicContext())
            {
                try
                {
                    var patients = await db.Patients.ToListAsync();
                    Patients = new ObservableCollection<Patient>(patients);
                    var workers = await db.Workers.ToListAsync();
                    Workers = new ObservableCollection<Worker>(workers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void GenerateTime()
        {
            TimeSpan Start = new TimeSpan(8, 0, 0);
            TimeSpan End = new TimeSpan(20, 0, 0);
            TimeSpan Interval = TimeSpan.FromMinutes(30);
            TimeSlotsCollection = new ObservableCollection<TimeSlot>();
            for (TimeSpan time = Start; time <= End; time = time.Add(Interval))
            {
                TimeSlotsCollection.Add(new TimeSlot
                {
                    Time = time.ToString(@"hh\:mm")
                });
            }
        }
        void CreateAppointment()
        {
            AppValidation = new AppointmentValidation();
            AppValidation.ValidationApp(SelectedPatient, SelectedWorker, Date, SelectedTimeSlot);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
