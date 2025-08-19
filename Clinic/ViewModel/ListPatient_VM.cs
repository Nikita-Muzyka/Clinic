using Clinic.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Clinic.ViewModel
{
    internal class ListPatient_VM : INotifyPropertyChanged
    {
        ObservableCollection<Patient> _patients;
        public ICommand ChangePatientCommand;
        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropetyChanged();
            }
        }
        public ListPatient_VM() 
        {
            LoadPatient();
            ChangePatientCommand = new RelayCommand(ChangePatient);
        }

        async void LoadPatient()
        {
            await CheckedDBpatient();
        }
        async Task CheckedDBpatient()
        {
            using (var db = new ClinicContext())
            {
                try
                {
                    var freePatients = await db.Patients.ToListAsync();
                    if (freePatients is not null)
                    {
                        Patients = new ObservableCollection<Patient>(freePatients);
                        MessageBox.Show("Созданы");
                    }
                    else MessageBox.Show("Пациентов нету");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void ChangePatient()
        {
            MessageBox.Show("111");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string PropertyChange = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyChange));
        }
    }
}
