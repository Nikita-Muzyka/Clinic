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
            string? Phone,
            string? Email,
            string? Weight,
            string? Gender,
            string? DateBirth)
        {
            var errors = new Dictionary<string, string>();

            //FirstName
            if (string.IsNullOrWhiteSpace(FirstName) == true || FirstName.Any(char.IsNumber) == true)            
                errors.Add("firstNameBox", "Пустая строка или есть цифры в имени");
            
            else if(FirstName.Length < 2)            
                errors.Add("firstNameBox","Имя содержит меньше 2 символов");

            else
            {
                bool result = false;
                for (int i = 1; i < FirstName.Length; i++)
                {
                    result = char.IsUpper(FirstName[i]);
                    if(result == true)
                    {
                        errors.Add("firstNameBox", "Имя содержит заглавные буквы");
                        break;
                    }
                }
                if(result == false)
                for (int i = 0; i < 1; i++)
                {
                    result = char.IsLower(FirstName[i]);
                    if(result == true)
                    {
                        errors.Add("firstNameBox", "Имя должно начинаться с заглавной буквы");
                    }
                }
            }

            //LastName
            if (string.IsNullOrWhiteSpace(LastName) == true || LastName.Any(char.IsNumber) == true)
                errors.Add("lastNameBox", "Пустая строка или есть цифры");
            else if (LastName.Length < 2)
                errors.Add("lastNameBox", "Фамилия содержит меньше 2 символов");
            else
            {
                bool result = false;
                for (int i = 1; i < LastName.Length; i++)
                {
                    result = char.IsUpper(LastName[i]);
                    if (result == true)
                    {
                        errors.Add("lastNameBox", "Фамилия содержит заглавные буквы");
                        break;
                    }
                }
                if (result == false)
                    for (int i = 0; i < 1; i++)
                    {
                        result = char.IsLower(LastName[i]);
                        if (result == true)
                        {
                            errors.Add("lastNameBox", "Фамилия должна начинаться с заглавной буквы");
                        }
                    }
            }

            //Patronymic
            if(string.IsNullOrWhiteSpace(LastName) == false || Patronymic.Length > 2) 
            {
                bool result = false;
                for (int i = 1; i < Patronymic.Length; i++)
                {
                    result = char.IsUpper(Patronymic[i]);
                    if (result == true)
                    {
                        errors.Add("patronymicBox", "Отчество содержит заглавные буквы");
                        break;
                    }
                }
                if (result == false)
                    for (int i = 0; i < 1; i++)
                    {
                        result = char.IsLower(FirstName[i]);
                        if (result == true)
                        {
                            errors.Add("patronymicBox", "Отчество должно начинаться с заглавной буквы");
                        }
                    }
            }


            //Phone
            if (string.IsNullOrWhiteSpace(Phone) == true || Phone.Any(char.IsNumber) == false)
                errors.Add("phoneBox", "Контакты обязательны для заполнения или должны содежрать только цифры");

            else if (Phone.Length < 11)
                errors.Add("phoneBox", "Минимально 5 символов номера");

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
                errors.Add("genderBox", "Пустая строка");

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
