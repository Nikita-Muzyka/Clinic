using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Appointment
    {
        public int Id { get; set; }
        public int Id_Workers { get; set; }
        public int Id_Patients { get; set; }
        public DateTime Date { get; set; }
    }
}
