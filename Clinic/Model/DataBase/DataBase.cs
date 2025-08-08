using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class Database
    {
        // Единственный экземпляр (Singleton)
        private static Database _instance;
        public static Database Instance => _instance ??= new Database();

        // Список пациентов
        public Worker Worker { get; set; } = new Worker();

        // Приватный конструктор (чтобы нельзя было создать новый экземпляр)
        private Database()
        {
            
        }
    }
}
