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

            return errors;
        }
    }
}
