using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Doctor
{
    internal class DoctorsContext : DbContext
    {
        public DbSet<Doctors> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Clinic;Trusted_Connection=true;");
        }
    }
}
