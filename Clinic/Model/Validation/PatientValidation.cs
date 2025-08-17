using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic
{
    public class PatientValidation
    {
        ObservableCollection<Brush> BrushCollection;
        ObservableCollection<string> ToolTipCollection;
        Patient _patient;

        byte Errors = 0;
        DateTime _date;
        int WeightConvert;

        DateTime Date
        {
            get => _date;
            set => _date = value.Date;
        }

        public PatientValidation(ObservableCollection<Brush> _brushCollection, ObservableCollection<string> _toolTipCollection) 
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
            if(BrushCollection is not null)
            for (int i = 0; i < BrushCollection.Count; i++)
            {
                BrushCollection[i] = Brushes.Transparent;
                ToolTipCollection[i] = "";
                Errors = 0;
            }
        }
        void ChangeColorBrush()
        {
            for (int i = 0; i < BrushCollection.Count ; i++)
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
         internal Patient Validation(
            string? FirstName,
            string? LastName,
            string? Patronymic,
            string? date,
            string? Gender,
            string? Weight,
            string? Phone,
            string? Email,
            string? Place,
            string? Diagnosis)
        {
            ThrowOff();
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
                if(Patronymic.Length >= 2)
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
                if (string.IsNullOrWhiteSpace(date) == true)
                {
                    BrushCollection[3] = Brushes.Red;
                    ToolTipCollection[3] = "Выберите дату";
                }
            else
            {
                Date = DateTime.Parse(date);
                if(Date > DateTime.Now)
                {
                    BrushCollection[3] = Brushes.Red;
                    ToolTipCollection[3] = "Дата рождения не может быть в будущем";
                }
            }

            //Gender
            if (string.IsNullOrWhiteSpace(Gender) == true)
            {
                BrushCollection[4] = Brushes.Red;
                ToolTipCollection[4] = "Пустая строка";
            }

            //Weight
            if (string.IsNullOrWhiteSpace(Weight) == true
                || Weight.Any(char.IsLetter) == true
                || Weight.Any(char.IsPunctuation) == true
                || Weight.Any(char.IsSymbol) == true)
            {
                BrushCollection[5] = Brushes.Red;
                ToolTipCollection[5] = "Контакты обязательны для заполнения или должны содежрать только цифры";
            }
            else
            {
                WeightConvert = int.Parse(Weight);
            }

            //Phone
            if (string.IsNullOrWhiteSpace(Phone) == true || Phone.Any(char.IsNumber) == false)
            {
                BrushCollection[6] = Brushes.Red;
                ToolTipCollection[6] = "Контакты обязательны для заполнения или должны содежрать только цифры";

            }
            else if (Phone.Length < 11)
            {
                BrushCollection[6] = Brushes.Red;
                ToolTipCollection[6] = "Минимально 5 символов номера";
            }

            //Email
            if (string.IsNullOrWhiteSpace(Email) == true)
            {
                BrushCollection[7] = Brushes.Red;
                ToolTipCollection[7] = "Email обязателен для заполнения";

            }

            ChangeColorBrush();
            if (Errors is 0) _patient = new Patient(FirstName, LastName, Patronymic, Date, Gender, WeightConvert, Phone, Email, Place, Diagnosis);
            return _patient;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
