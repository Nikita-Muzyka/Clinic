using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ClinicPersonal
{
    public class PatientValidation
    {
        public Dictionary<string, string> Validation(
            string? FirstName,
            string? LastName,
            string? Patronymic,
            string? Contact,
            string? Weight,
            string? Gender,
            string? DateBirth)
        {
            var errors = new Dictionary<string, string>();

            //FirstName
            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Any(char.IsNumber) == true)
            {
                errors.Add("firstNameBox","Пустая строка или есть цифры");
            }
            else if (FirstName.Length < 2)
            {
                errors.Add("firstNameBox", "Имя содержит меньше 2 символов");
            }

            //LastName
            if (string.IsNullOrWhiteSpace(LastName) || LastName.Any(char.IsNumber) == true)
            {
                errors.Add("lastNameBox", "Пустая строка или есть цифры");
            }
            else if (LastName.Length < 2)
            {
                errors.Add("lastNameBox", "Фамилия содержит меньше 2 символов");
            }

            ////Patronymic
            //if (Patronymic.All(char.IsWhiteSpace))
            //{
            //    errors.Add("patronymicBox", "Пустые строки");
            //}

            //Contact
            if (string.IsNullOrWhiteSpace(Contact) || Contact.Any(char.IsNumber) == false)
            {
                errors.Add("contactBox", "Контакты обязательны для заполнения или должны содежрать только цифры");
            }
            else if (Contact.Length < 5)
            {
                errors.Add("contactBox", "Минимально 5 символов номера");
            }

            //Weight
            if (string.IsNullOrWhiteSpace(Weight) || Weight.Any(char.IsNumber) == false)
            {
                errors.Add("weightBox", "Строка должна быть заполнена или Номер должен содержать только цифры");
            }
            else
            {
                int Weight32 = int.Parse(Weight);
                if (Weight32 < 0 || Weight32 > 400)
                {
                    errors.Add("weightBox", "Вес должен быть от 1 до 400");
                }
            }

            //Gender
            if (string.IsNullOrWhiteSpace(Gender))
            {
                errors.Add("genderBox", "Пустая строка");
            }

            if (string.IsNullOrWhiteSpace(DateBirth))
            {
                errors.Add("datebirthBox", "Пустая строка");
            }

            return errors;
        }
    }
}
