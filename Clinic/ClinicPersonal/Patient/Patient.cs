using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Patient : ClinicPerson
    {
        public override int Id { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string Patronymic { get; set; }
        public override string Gender { get; set; }
        public override string Contact { get; set; }
        public override byte Age { get; set; }
        public override string Place { get; set; }
        public MedCard MedCard { get; set; }
    }
}
