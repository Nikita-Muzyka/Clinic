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
            if (string.IsNullOrWhiteSpace(FirstName) == true || FirstName.Any(char.IsNumber) == true)
            {
                errors.Add("firstNameBox","Пустая строка или есть цифры");
            }
            else if (FirstName.Length < 2)
            {
                errors.Add("firstNameBox", "Имя содержит меньше 2 символов");
            }

            //LastName
            if (string.IsNullOrWhiteSpace(LastName) == true || LastName.Any(char.IsNumber) == true)
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
            if (string.IsNullOrWhiteSpace(Contact) == true || Contact.Any(char.IsNumber) == true)
            {
                errors.Add("contactBox", "Контакты обязательны для заполнения или должны содежрать только цифры");
            }
            else if (Contact.Length < 5)
            {
                errors.Add("contactBox", "Минимально 5 символов номера");
            }

            //Weight
            if (string.IsNullOrWhiteSpace(Weight) == true
                || Weight.Any(char.IsLetter) == true
                || Weight.Any(char.IsPunctuation) == true
                || Weight.Any(char.IsSymbol) == true)
            {
                errors.Add("weightBox", "Строка должна быть заполнена или Номер должен содержать только цифры");
            }
         

            //Gender
            if (string.IsNullOrWhiteSpace(Gender) == true)
            {
                errors.Add("genderBox", "Пустая строка");
            }

            //DateBirth
            if(string.IsNullOrWhiteSpace(DateBirth) == false)
            {
                DateTime? time;
                time = DateTime.Parse(DateBirth);
                if (time > DateTime.Now)
                {
                    errors.Add("datebirthBox", "Нельзя вводить будущее время");
                }
            }
            else
            {
                errors.Add("datebirthBox", "Поле обязательно для заполнения");
            }

            return errors;
        }
    }
}
