using Hospital.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorID);
            builder.Property(d => d.Name).HasMaxLength(50).IsRequired();
            builder.Property(d => d.Speciality).HasMaxLength(50).IsRequired();
            builder.Property(d => d.Phone).HasMaxLength(15).IsRequired();
            builder.Property(d => d.Email).HasMaxLength(50).IsRequired();
            builder.Property(d => d.Address).HasMaxLength(100).IsRequired();
        }
        
    }
}