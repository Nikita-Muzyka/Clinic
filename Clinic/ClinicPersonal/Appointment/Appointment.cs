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
        public ClinicPerson Workers { get; set; }
        public ClinicPerson Patients { get; set; }
        public DateTime Date { get; set; }
    }
}
