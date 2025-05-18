using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Doctors
    {
        public byte Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }
        public DoctorsPassword infoReg { get; set; }
    }
    class DoctorsPassword
    {
        public byte Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
