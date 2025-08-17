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
        bool CheckValidation = false;
        byte Errors = 0;

        public PatientValidation(ObservableCollection<Brush> _brushCollection, ObservableCollection<string> _toolTipCollection) 
        {
            BrushCollection = _brushCollection;
            ToolTipCollection = _toolTipCollection;
            BrushCollectionPull();
        }

        void BrushCollectionPull()
        {
            for (int i = 0; i < 9; i++)
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

        public bool Validation(
            string? FirstName,
            string? LastName,
            string? Patronymic,
             string? DateBirth,
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
            if (string.IsNullOrWhiteSpace(LastName) == false)
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
                        result = char.IsLower(FirstName[i]);
                        if (result == true)
                        {
                            BrushCollection[2] = Brushes.Red;
                            ToolTipCollection[2] = "Отчество должно начинаться с заглавной буквы";
                        }
                    }
            }

            //DateBirth
            if (string.IsNullOrWhiteSpace(DateBirth) == false)
            {
                DateTime? time;
                time = DateTime.Parse(DateBirth);
                if (time > DateTime.Now)
                {
                    BrushCollection[3] = Brushes.Red;
                    ToolTipCollection[3] = "Нельзя вводить будущее время";
                }
            }
            else
            {
                BrushCollection[3] = Brushes.Red;
                ToolTipCollection[3] = "Поле обязательно для заполнения";
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

            if (Errors is 0) CheckValidation = true;
            return CheckValidation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
