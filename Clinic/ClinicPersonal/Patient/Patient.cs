using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clinic
{
    public class Patient : ClinicPerson,IPatient
    {
        public override int Id { get; set; }
        public override string? FirstName { get; set; }
        public override string? LastName { get; set; }
        public override string? Patronymic { get; set; }
        public override string? Gender { get; set; }
        public override string? Contact { get; set; }
        public override string? DateBrith { get; set; }
        public override string? Place { get; set; }
        public override string? YearsCreate { get; set; } // год создания
        public string? Diagnosis { get; set; } // диагнозы
        public int? Weight { get; set; } // вес

    }
}
