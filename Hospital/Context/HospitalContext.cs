using Hospital.Configuration;
using Hospital.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Context
{
    public class HospitalContext:DbContext
    {

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                   .UseSqlServer("Data source = .; Initial catalog = DB_Hospital; Integrated security= true; trustservercertificate = true;")
                   .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Client> Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            // modelBuilder.Entity<Doctor>().Property(d => d.Name).HasMaxLength(50).IsRequired();
            // modelBuilder.Entity<Doctor>().Property(d => d.Speciality).HasMaxLength(50).IsRequired();
            // modelBuilder.Entity<Doctor>().Property(d => d.Phone).HasMaxLength(15).IsRequired();
            // modelBuilder.Entity<Doctor>().Property(d => d.Email).HasMaxLength(50).IsRequired();
            // modelBuilder.Entity<Doctor>().Property(d => d.Address).HasMaxLength(100).IsRequired();

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            base.OnModelCreating(modelBuilder);
        }

      


    }
}
