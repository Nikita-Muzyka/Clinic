using Clinic.Doctor;
using Clinic.Model.FrameServise;
using Clinic.Pages;
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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Clinic.ViewModel
{
    internal class ListPatient_VM : INotifyPropertyChanged
    {
        ObservableCollection<Patient> _patients;
        Patient _patient;
        FrameServise _frameServise;
        public ICommand ChangePatientCommand { get; }
        public ICommand DeletePatientCommand { get; }

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropetyChanged();
            }
        }
        public Patient SelectedPatient { get; set; }
        public Patient Patient { get; set; }

        Action<Patient> ChangePatient = (SelectedPatient) =>
        {
            if(SelectedPatient is not null)
            {
                Database.Instance.Patient = SelectedPatient;
                FrameServise.NavigateInvoke();
            }
            else
            {
                MessageBox.Show("Выберите Карточку");
            }
        };


        public ListPatient_VM() 
        {
            LoadPatient();
            ChangePatientCommand = new RelayCommand(() => ChangePatient(SelectedPatient));
            DeletePatientCommand = new RelayCommand(DeletePatient);
        }

        async void LoadPatient()
        {
            await CheckedDBpatientAsync();
        }
        async void DeletePatient()
        {
            await DeletePatientDBAsync();
        }
        async Task CheckedDBpatientAsync()
        {
            using (var db = new ClinicContext())
            {
                try
                {
                    var freePatients = await db.Patients.ToListAsync();
                    if (freePatients is not null)
                    {
                        Patients = new ObservableCollection<Patient>(freePatients);
                    }
                    else MessageBox.Show("Пациентов нету");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        async Task DeletePatientDBAsync()
        {
            _patient = SelectedPatient;

            var result = MessageBox.Show($"Удалить пациента {_patient.LastName}?",
                                      "Подтверждение",
                                      MessageBoxButton.YesNo,
                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new ClinicContext())
                    {
                        var dbPatient = await db.Patients.FindAsync(_patient.Id);
                        db.Patients.Remove(dbPatient);
                        await db.SaveChangesAsync();
                    }
                    Patients.Remove(_patient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string PropertyChange = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyChange));
        }
    }
}
