using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.AbstractModels;

namespace VeterinaryClinic.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClinicDepartment> Departments { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<ClinicDepartment>()
                .HasMany(c => c.Veterinarians)
                .WithOne(v => v.ClinicDepartment)
                .HasForeignKey(v => v.ClinicDepartmentId);

            modelBuilder.Entity<ClinicDepartment>()
                .HasMany(c => c.Pets)
                .WithOne(p => p.ClinicDepartment)
                .HasForeignKey(p => p.ClinicDepartmentId);

            
            modelBuilder.Entity<Veterinarian>()
                .HasMany(v => v.Pets)
                .WithOne(p => p.Veterinarian)
                .HasForeignKey(p => p.VeterinarianId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=veterinary_clinic;Username=postgres;Password=postgres");
        }
    }
}
