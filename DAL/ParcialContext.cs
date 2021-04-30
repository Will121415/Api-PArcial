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


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // modelBuilder.Entity<Appointment>()
        //     //     .HasOne<Patient>(p => p.Patient)
        //     //     .WithMany(b => b.appointments)
        //     //     .HasForeignKey(c => c.AppointmentId);

        //     // modelBuilder.Entity<Appointment>()
        //     //     .HasOne<UserAttentionStaff>(p => p.UserAttentionStaff)
        //     //     .WithMany(b => b.appointments)
        //     //     .HasForeignKey(c => c.AppointmentId);

        //     modelBuilder.Entity<Patient>()
        //         .HasKey(b => b.PatientId)
        //         .HasName("PrimaryKey_PatientId");

        //     modelBuilder
        //     .Entity<Patient>()
        //     .Property(e => e.PatientId)
        //     .ValueGeneratedOnAdd();

        //     modelBuilder.Entity<User>()
        //         .HasKey(b => b.UserName)
        //         .HasName("PrimaryKey_UserName");
            
        //     modelBuilder.Entity<UserAdmin>()
        //         .HasKey(b => b.AdminId)
        //         .HasName("PrimaryKey_AdminId");

        //     modelBuilder.Entity<UserAttentionStaff>()
        //         .HasKey(b => b.AttentionId)
        //         .HasName("PrimaryKey_AttentionId");
        // }


    }
}