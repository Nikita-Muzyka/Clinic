using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Clinic
{
    internal class WorkerValidation
    {
        public ClinicRole RoleConver(string Role)
        {
            ClinicRole RoleChange = ClinicRole.Nurse;
            switch (Role)
            {
                case "Глав.Врач":
                    RoleChange = ClinicRole.HDoctor;
                    break;
                case "Зам.Глав.Врача":
                    RoleChange = ClinicRole.MDoctor;
                    break;
                case "Зав.Отделения":
                    RoleChange = ClinicRole.LDoctor;
                    break;
                case "Доктор":
                    RoleChange = ClinicRole.Doctor;
                    break;
                case "Регистратура":
                    RoleChange = ClinicRole.Register;
                    break;
                case "Мед.Сестра":
                    RoleChange = ClinicRole.Nurse;
                    break;
            }
            return RoleChange;
        }

        public Dictionary<string,string> Validation(
            string? FirstName,
            string? LastName,
            string? Patronymic,
            string? DateBirth,
            string? Gender,
            string? Phone,
            string? Email,
            string? Place,
            string? Role,
            string? Login,
            string? Password) 
        {
            var errors = new Dictionary<string, string>();
            ClinicRole RoleChange = ClinicRole.Nurse;

            //FirstName
            if (string.IsNullOrWhiteSpace(FirstName) == true || FirstName.Any(char.IsNumber) == true)
                errors.Add("firstNameBox", "Пустая строка или есть цифры в имени");

            else if (FirstName.Length < 2)
                errors.Add("firstNameBox", "Имя содержит меньше 2 символов");

            else
            {
                bool result = false;
                for (int i = 1; i < FirstName.Length; i++)
                {
                    result = char.IsUpper(FirstName[i]);
                    if (result == true)
                    {
                        errors.Add("firstNameBox", "Имя содержит заглавные буквы");
                        break;
                    }
                }
                if (result == false)
                    for (int i = 0; i < 1; i++)
                    {
                        result = char.IsLower(FirstName[i]);
                        if (result == true)
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
            if (string.IsNullOrWhiteSpace(LastName) == false || Patronymic.Length > 2)
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

            //Email
            if (string.IsNullOrWhiteSpace(Phone) == true)
                errors.Add("emailBox", "Email обязателен для заполнения");


            //Gender
            if (string.IsNullOrWhiteSpace(Gender) == true)
                errors.Add("genderBox", "Пустая строка");

            //DateBirth
            if (string.IsNullOrWhiteSpace(DateBirth) == false)
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

            //Role
            if (!string.IsNullOrWhiteSpace(Role))
            {
                RoleChange = RoleConver(Role);
                if (Database.Instance.Worker.CheckedRole() > RoleChange);
                else errors.Add("roleBox", "Ваша должность ниже или равна выбранной");
            }
            else errors.Add("roleBox", "Выберите должность");

            //Login

             if (Login.Length < 5)
                errors.Add("logBox", "Логин не может быть короче 5 символов");
            else if (!string.IsNullOrWhiteSpace(Login) == true)
                errors.Add("logBox", "Логин не может быть пустым");
            //Password
            if (Login.Length < 5)
                errors.Add("passBox", "Логин не может быть короче 5 символов");
            else if (!string.IsNullOrWhiteSpace(Password) == true)
                errors.Add("passBox", "Пароль не может быть пустым");
            else if (Password.Any(char.IsUpper) == false || Password.Any(char.IsSymbol) == false || Password.Any(char.IsNumber) == false)
                errors.Add("passBox", "Пароль должен содержать хотя-бы одну заглавнуюб букву,один символ (+, &, © и т. д.), и хотя-бы одну цифру");

             return errors;
        }
    }
}
