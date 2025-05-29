using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ClinicPersonal.Worker
{
    public interface IWorker
    {
        public string Salary { get; set; }
        public TitleWorker Title { get; set; }
        public PeopleRegistration infoReg { get; set; }
    }
}
