using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.ClinicPersonal.Worker;

namespace Clinic
{
    public class Worker : ClinicPerson,IWorker
    {
        public override int Id { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string? Patronymic { get; set; }
        public override string Gender { get; set; }
        public override string Contact { get; set; }
        public override byte DateBrith { get; set; }
        public override string Place { get; set; }
        public string Salary { get; set; }
        public string Title { get; set; }
        public PeopleRegistration infoReg { get; set; }

    }
}
