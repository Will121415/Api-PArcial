using Microsoft.EntityFrameworkCore;
using Entity;
namespace DAL
{
    public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions options) : base(options) { }


        public DbSet<User> Users { set; get; }
        public DbSet<UserAdmin> UserAdmins { set; get; }
        public DbSet<UserAttentionStaff> UserAttentionStaffs { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Appointment> Appointments { set; get; }

    }
}