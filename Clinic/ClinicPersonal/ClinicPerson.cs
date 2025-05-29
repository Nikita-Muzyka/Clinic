using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public abstract class ClinicPerson
    {
        public abstract int Id { get; set; }
        public abstract string FirstName { get; set; } // имя
        public abstract string LastName { get; set; } // фамилия
        public abstract string Patronymic { get; set; } // Отчество
        public abstract string Gender { get; set; } // пол
        public abstract string Contact { get; set; } // телефон
        public abstract byte Age { get; set; } // возраст
        public abstract string Place { get; set; } // место проживание 
    } 
}
