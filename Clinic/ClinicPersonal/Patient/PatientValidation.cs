using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ClinicPersonal
{
    public class PatientValidation
    {
        public Dictionary<string, string> Validation(Patient patient)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(patient.FirstName) || patient.FirstName.Any(char.IsNumber) == true)
            {
                errors.Add("firstNameBox","Пустая строка или есть цифры");
            }
            else if (patient.FirstName.Length < 2)
            {
                errors.Add("firstNameBox", "Имя содержит меньше 2 символов");
            }

            if (string.IsNullOrWhiteSpace(patient.LastName) || patient.LastName.Any(char.IsNumber) == true)
            {
                errors.Add("lastNameBox", "Пустая строка или есть цифры");
            }
            else if (patient.LastName.Length < 2)
            {
                errors.Add("lastNameBox", "Фамилия содержит меньше 2 символов");
            }

            if (string.IsNullOrWhiteSpace(patient.Contact))
            {
                errors.Add("contactBox", "Контакты обязательны");
            }
            else if (patient.Contact.Length < 5)
            {
                errors.Add("contactBox", "Минимально 5 символов номера");
            }

            return errors;
        }
    }
}
