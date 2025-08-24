using Clinic.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clinic
{
    internal class AppointmentPage_VM : INotifyPropertyChanged
    {
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

        public AppointmentPage_VM()
        {
            LoadUsers();
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



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
