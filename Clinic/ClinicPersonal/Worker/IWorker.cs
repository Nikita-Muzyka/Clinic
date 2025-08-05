using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal interface IWorker
    {
        public string Salary { get; set; }
        public ClinicRole Role { get; }
        public PeopleRegistration infoReg { get; }
    }
}
