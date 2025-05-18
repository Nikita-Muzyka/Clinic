using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    abstract class ClinicPersonal
    {
        public abstract int Id { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract byte Age { get; set; }
        public abstract string Salary { get; set; }
        public abstract TitleWorker Title { get; set; }
        public abstract PeopleRegistration infoReg { get; set; }
    }
}
