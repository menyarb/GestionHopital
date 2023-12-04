using GestionHopital.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionHopital.data
{
    public class HopitalDbContext : DbContext

    {
        public HopitalDbContext(DbContextOptions options): base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<OtherStaff> OtherStaffs { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }

    }
}
