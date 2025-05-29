using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Clinic
{
    public interface IPatient
    {
        public string Diagnosis { get; set; } // диагнозы
        public string Weight { get; set; } // вес
        public string YearsCreate { get; set; } // год создания
    }
}
