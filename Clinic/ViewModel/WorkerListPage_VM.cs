using Clinic.Doctor;
using Clinic.Model.FrameServise;
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
using System.Windows.Input;

namespace Clinic.ViewModel
{
    internal class WorkerListPage_VM
    {
        ObservableCollection<Worker> _workers;
        Worker _worker;
        FrameServise _frameServise;
        public ICommand ChangeWorkerCommand { get; }
        public ICommand DeleteWorkerCommand { get; }

        public ObservableCollection<Worker> Workers
        {
            get => _workers;
            set
            {
                _workers = value;
                OnPropetyChanged();
            }
        }
        public Worker SelectedWorker { get; set; }
        public Worker Worker { get; set; }

        Action<Worker> ChangeWorker = (SelectedWorker) =>
        {
            if (SelectedWorker is not null)
            {
                Database.Instance.Worker = SelectedWorker;
                FrameServise.NavigateCreateWorkerInvoke();
            }
            else
            {
                MessageBox.Show("Выберите Карточку");
            }
        };


        public WorkerListPage_VM()
        {
            LoadWorker();
            ChangeWorkerCommand = new RelayCommand(() => ChangeWorker(SelectedWorker));
            DeleteWorkerCommand = new RelayCommand(DeleteWorker);
        }

        async void LoadWorker()
        {
            await CheckedDBWorkerAsync();
        }
        async void DeleteWorker()
        {
            await DeleteWorkerDBAsync();
        }
        async Task CheckedDBWorkerAsync()
        {
            using (var db = new ClinicContext())
            {
                try
                {
                    var freeWorkers = await db.Workers.ToListAsync();
                    if (freeWorkers is not null)
                    {
                        Workers = new ObservableCollection<Worker>(freeWorkers);
                    }
                    else MessageBox.Show("Пациентов нету");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        async Task DeleteWorkerDBAsync()
        {
            _worker = SelectedWorker;

            var result = MessageBox.Show($"Удалить пациента {_worker.LastName}?",
                                      "Подтверждение",
                                      MessageBoxButton.YesNo,
                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await using (var db = new ClinicContext())
                    {
                        var dbPatient = await db.Patients.FindAsync(_worker.Id);
                        db.Patients.Remove(dbPatient);
                        await db.SaveChangesAsync();
                    }
                    Workers.Remove(_worker);
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
