using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic
{
    internal class WorkerValidation
    {
        ObservableCollection<Brush> BrushCollection;
        ObservableCollection<string> ToolTipCollection;
        Worker _worker;
        DateTime Date;

        byte Errors = 0;

        public WorkerValidation(ObservableCollection<Brush> _brushCollection, ObservableCollection<string> _toolTipCollection)
        {
            BrushCollection = _brushCollection;
            ToolTipCollection = _toolTipCollection;
            BrushCollectionPull();
        }

        void BrushCollectionPull()
        {
            for (int i = 0; i < 10; i++)
            {
                BrushCollection.Add(Brushes.Transparent);
                ToolTipCollection.Add("");
            }
        }
        void ThrowOff()
        {
            if (BrushCollection is not null)
                for (int i = 0; i < BrushCollection.Count; i++)
                {
                    BrushCollection[i] = Brushes.Transparent;
                    ToolTipCollection[i] = "";
                    Errors = 0;
                }
        }
        void ChangeColorBrush()
        {
            for (int i = 0; i < BrushCollection.Count; i++)
            {
                if (BrushCollection[i] == Brushes.Transparent)
                {
                    BrushCollection[i] = Brushes.LightGreen;
                }
                else
                {
                    Errors++;
                }
            }
        }
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

        internal Worker Validation(
            string? FirstName,
            string? LastName,
            string? Patronymic,
            DateTime date,
            string? Gender,
            string? Phone,
            string? Email,
            string? Place,
            string? Salary,
            string? Role,
            string? Login,
            string? Password)
        {
            ThrowOff();
            ClinicRole RoleChange = ClinicRole.Nurse;

            //FirstName
            if (string.IsNullOrWhiteSpace(FirstName) == true || FirstName.Any(char.IsNumber) == true)
            {
                BrushCollection[0] = Brushes.Red;
                ToolTipCollection[0] = "Строка пустая или имеются цифры в имени";
            }
            else if (FirstName.Length < 2)
            {
                BrushCollection[0] = Brushes.Red;
                ToolTipCollection[0] = "Имя содержит меньше 2 символов";
            }
            else
            {
                bool result = false;
                for (int i = 1; i < FirstName.Length; i++)
                {
                    result = char.IsUpper(FirstName[i]);
                    if (result == true)
                    {
                        BrushCollection[0] = Brushes.Red;
                        ToolTipCollection[0] = "Имя содержит заглавные буквы";
                        break;
                    }
                }
                if (result == false)
                    for (int i = 0; i < 1; i++)
                    {
                        result = char.IsLower(FirstName[i]);
                        if (result == true)
                        {
                            BrushCollection[0] = Brushes.Red;
                            ToolTipCollection[0] = "Имя должно начинаться с заглавной буквы";
                        }
                    }
            }

            //LastName
            if (string.IsNullOrWhiteSpace(LastName) == true || LastName.Any(char.IsNumber) == true)
            {
                BrushCollection[1] = Brushes.Red;
                ToolTipCollection[1] = "Пустая строка или есть цифры";
            }
            else if (LastName.Length < 2)
            {
                BrushCollection[1] = Brushes.Red;
                ToolTipCollection[1] = "Фамилия содержит меньше 2 символов";
            }
            else
            {
                bool result = false;
                for (int i = 1; i < LastName.Length; i++)
                {
                    result = char.IsUpper(LastName[i]);
                    if (result == true)
                    {
                        BrushCollection[1] = Brushes.Red;
                        ToolTipCollection[1] = "Фамилия содержит заглавные буквы";
                        break;
                    }
                }
                if (result == false)
                    for (int i = 0; i < 1; i++)
                    {
                        result = char.IsLower(LastName[i]);
                        if (result == true)
                        {
                            BrushCollection[1] = Brushes.Red;
                            ToolTipCollection[1] = "Фамилия должна начинаться с заглавной буквы";
                        }
                    }
            }

            //Patronymic
            if (string.IsNullOrWhiteSpace(Patronymic) == false)
            {
                if (Patronymic.Length >= 2)
                {
                    bool result = false;
                    for (int i = 1; i < Patronymic.Length; i++)
                    {
                        result = char.IsUpper(Patronymic[i]);
                        if (result == true)
                        {
                            BrushCollection[2] = Brushes.Red;
                            ToolTipCollection[2] = "Отчество содержит заглавные буквы";
                            break;
                        }
                    }
                    if (result == false)
                        for (int i = 0; i < 1; i++)
                        {
                            result = char.IsLower(Patronymic[i]);
                            if (result == true)
                            {
                                BrushCollection[2] = Brushes.Red;
                                ToolTipCollection[2] = "Отчество должно начинаться с заглавной буквы";
                            }
                        }
                }
                else
                {
                    BrushCollection[2] = Brushes.Red;
                    ToolTipCollection[2] = "Отчество должно содержать больше 1 символа";
                }
            }

            //DateBirth
            if (date > DateTime.Now)
            {
                BrushCollection[3] = Brushes.Red;
                ToolTipCollection[3] = "Дата рождения не может быть в будущем или дата пуста";
            }
            else
            {
                Date = date.Date;
            }

            //Gender
            if (string.IsNullOrWhiteSpace(Gender) == true)
            {
                BrushCollection[4] = Brushes.Red;
                ToolTipCollection[4] = "Пустая строка";
            }

            //Phone
            if (string.IsNullOrWhiteSpace(Phone) == true || Phone.Any(char.IsNumber) == false)
            {
                BrushCollection[5] = Brushes.Red;
                ToolTipCollection[5] = "Контакты обязательны для заполнения или должны содежрать только цифры";

            }
            else if (Phone.Length < 11)
            {
                BrushCollection[5] = Brushes.Red;
                ToolTipCollection[5] = "Минимально 5 символов номера";
            }

            //Email
            if (string.IsNullOrWhiteSpace(Email) == true)
            {
                BrushCollection[6] = Brushes.Red;
                ToolTipCollection[6] = "Email обязателен для заполнения";

            }

            //Salary
            if (string.IsNullOrWhiteSpace(Salary) == true || Salary.Any(char.IsNumber) == false)
            {
                BrushCollection[8] = Brushes.Red;
                ToolTipCollection[8] = "Зарплата не может быть пустой или должна содержать только цифры";
            }

            //Role
            if (string.IsNullOrWhiteSpace(Role) == false)
            {
                RoleChange = RoleConver(Role);
                if (Database.Instance.Worker.CheckedRole() > RoleChange) ;
                else
                {
                    BrushCollection[9] = Brushes.Red;
                    ToolTipCollection[9] = "Ваша должность ниже или равна выбранной";
                }
            }
            else
            {
                BrushCollection[9] = Brushes.Red;
                ToolTipCollection[9] = "Выберите должность";
            }

            //Login

            if (Login.Length < 5)
            {
                BrushCollection[10] = Brushes.Red;
                ToolTipCollection[10] = "Логин не может быть короче 5 символов";
            }
            else if (string.IsNullOrWhiteSpace(Login) == true)
            {
                BrushCollection[10] = Brushes.Red;
                ToolTipCollection[10] = "Логин не может быть пустым";
            }

            //Password
            if (Password.Length < 5)
            {
                BrushCollection[11] = Brushes.Red;
                ToolTipCollection[11] = "Пароль не может быть короче 5 символов";
            }
            else if (string.IsNullOrWhiteSpace(Password) == true)
            {
                BrushCollection[11] = Brushes.Red;
                ToolTipCollection[11] = "Пароль не может быть пустым";
            }
            else if (Password.Any(char.IsUpper) == false || Password.Any(char.IsSymbol) == false || Password.Any(char.IsNumber) == false)
            {
                BrushCollection[11] = Brushes.Red;
                ToolTipCollection[11] = "Пароль должен содержать хотя - бы одну заглавнуюб букву,один символ(+, &, © и т. д.), и хотя-бы одну цифру";
            }

            ChangeColorBrush();
            if (Errors is 0) _worker = new Worker(FirstName, LastName, Patronymic, Date, Gender, Phone, Email, Place, Salary, RoleChange, Login, Password);
            return _worker;
        }
    }
}
