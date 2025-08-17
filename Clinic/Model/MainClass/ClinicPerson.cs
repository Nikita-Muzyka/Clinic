using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal abstract class ClinicPerson
    {
        public abstract int Id { get; set; }
        public abstract string FirstName { get; set; } // имя
        public abstract string LastName { get; set; } // фамилия
        public abstract string Patronymic { get; set; } // Отчество
        public abstract string Gender { get; set; } // пол
        public abstract string Phone { get; set; } // телефон
        public abstract string Email { get; set; } // email
        public abstract DateTime Date { get; set; } // возраст
        public abstract string Place { get; set; } // место проживание 
        public abstract DateTime YearsCreate { get; set; } // год создания

    }
}
