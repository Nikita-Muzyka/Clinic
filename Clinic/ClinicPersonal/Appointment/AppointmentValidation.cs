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
        public void ValidationApp(Patient patient, Worker worker, string date,string CheckTime)
        {
            if (string.IsNullOrWhiteSpace(date) == false || string.IsNullOrWhiteSpace(CheckTime) == false)
            {
                DateTime dateBrith = DateTime.Parse(date);
                TimeSpan timeSpan = TimeSpan.Parse(CheckTime);
                if (dateBrith > DateTime.Now)
                {
                    using (var db = new ClinicContext())
                    {
                        var App = db.Appointments
                             .Where(p => patient.Id == p.PatientId & worker.Id == p.WorkerId & dateBrith == p.Date && timeSpan == p.Time)
                             .ToList();
                        if (App.Count == 0)
                        {
                            Appointment = new Appointment
                            {
                                PatientId = patient.Id,
                                WorkerId = worker.Id,
                                Date = dateBrith,
                                Time = timeSpan
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
            else
            {
                MessageBox.Show("Выберите дату или время");
            }
        }
    }
}
