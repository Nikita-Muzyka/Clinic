using Clinic.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clinic
{
    internal class AppointmentValidation
    {
        Appointment Appointment;
        bool result = false;
        public void ValidationApp(Patient patient, Worker worker, string date)
        {
            if (string.IsNullOrWhiteSpace(date) == false)
            {
                DateTime dateBrith = DateTime.Parse(date);
                if (dateBrith > DateTime.Now)
                {
                    using (var db = new ClinicContext())
                    {
                        var App = db.Appointments
                             .Where(p => patient.Id == p.PatientId & worker.Id == p.WorkerId & dateBrith == p.Date)
                             .ToList();
                        if (App.Count == 0)
                        {
                            Appointment = new Appointment
                            {
                                PatientId = patient.Id,
                                WorkerId = worker.Id,
                                Date = dateBrith
                            };
                            db.Appointments.Add(Appointment);
                            db.SaveChanges();
                            MessageBox.Show("Прием назначен");
                        }
                        else
                        {
                            MessageBox.Show("Такой прием уже существует");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Дата не может быть в прошлом");
                }
            }
        }
    }
}
