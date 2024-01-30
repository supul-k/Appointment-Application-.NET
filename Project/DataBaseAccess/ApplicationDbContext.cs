using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.DataBaseAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ServiceTypeModel> ServiceTypes { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }

        public DbSet<ContactUsModel> ContactUs { get; set; }
    }
}

