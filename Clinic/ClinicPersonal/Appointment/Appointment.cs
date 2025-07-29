using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Appointment
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int PatientId { get; set; }

        public DateTime Date { get; set; }
    }
}
