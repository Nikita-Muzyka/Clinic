using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal interface IAdministrator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public PeopleRegistration infoReg { get; set; }
    }
}
