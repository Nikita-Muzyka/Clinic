using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Database
    {
        // Единственный экземпляр (Singleton)
        private static Database _instance;
        public static Database Instance => _instance ??= new Database();

        // Список пациентов
        public List<ClinicPerson> Patients { get; } = new List<ClinicPerson>();
        public List<ClinicPerson> Workers { get; } = new List<ClinicPerson>();
        public List<Appointment> Appos { get; } = new List<Appointment>();

        // Приватный конструктор (чтобы нельзя было создать новый экземпляр)
        private Database()
        {
            
        }
    }
}
