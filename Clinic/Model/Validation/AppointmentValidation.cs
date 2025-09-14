using Clinic.ClinicPersonal.Appointment;
using Clinic.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Clinic
{
    internal class AppointmentValidation
    {
        Appointment Appointment;
        bool result = false;
        public async void ValidationApp(Patient patient, Worker worker, DateTime Date,TimeSlot SelectedTimeSlot)
        {
            if (string.IsNullOrWhiteSpace(SelectedTimeSlot.Time) == false && Date > DateTime.Now)
            {
                TimeSpan timeSpan = TimeSpan.Parse(SelectedTimeSlot.Time);
                await CheckedValidationAsync(Date,timeSpan,patient,worker);
            }
            else
            {
                MessageBox.Show("Дата не может быть в прошлом");
            }
        }
        async Task CheckedValidationAsync(DateTime Date,TimeSpan Time, Patient patient, Worker worker)
        {
            await using (var db = new ClinicContext())
            {
                var App = await db.Appointments
                     .Where(p => patient.Id == p.PatientId & worker.Id == p.WorkerId & Date == p.Date && Time == p.Time)
                     .ToListAsync();
                if (App.Count == 0)
                {
                    Appointment = new Appointment
                    {
                        PatientId = patient.Id,
                        WorkerId = worker.Id,
                        Date = Date,
                        Time = Time
                    };
                    await db.Appointments.AddAsync(Appointment);
                    await db.SaveChangesAsync   ();
                    MessageBox.Show("Прием назначен");
                }
                else
                {
                    MessageBox.Show("Такой прием уже существует");
                }
            }
        }
    }
}
