using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Clinic
{
    public class MedCard
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } // диагнозы
        public string CardNumber { get; set; } // номер карты
        public string Weight { get; set; } // вес
    }
}
