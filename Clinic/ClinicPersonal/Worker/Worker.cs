using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Worker : ClinicPersonal
    {
        public override int Id { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override byte Age { get; set; }
        public override string Salary { get; set; }
        public override TitleWorker Title { get; set; }
        public override PeopleRegistration infoReg { get; set; }
    }
}
