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
        public async void ValidationApp(Patient patient, Worker worker, string date,string CheckTime)
        {
            if (string.IsNullOrWhiteSpace(date) == false || string.IsNullOrWhiteSpace(CheckTime) == false)
            {
                DateTime dateBrith = DateTime.Parse(date);
                TimeSpan timeSpan = TimeSpan.Parse(CheckTime);
                if (dateBrith > DateTime.Now)
                {
                    await CheckedValidationAsync(dateBrith,timeSpan,patient,worker);
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
        async Task CheckedValidationAsync(DateTime dateBrith,TimeSpan timeSpan, Patient patient, Worker worker)
        {
            await using (var db = new ClinicContext())
            {
                var App = await db.Appointments
                     .Where(p => patient.Id == p.PatientId & worker.Id == p.WorkerId & dateBrith == p.Date && timeSpan == p.Time)
                     .ToListAsync();
                if (App.Count == 0)
                {
                    Appointment = new Appointment
                    {
                        PatientId = patient.Id,
                        WorkerId = worker.Id,
                        Date = dateBrith,
                        Time = timeSpan
                    };
                    await db.Appointments.AddAsync(Appointment);
                    await db.SaveChangesAsync();
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
