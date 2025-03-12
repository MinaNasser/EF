using Hospital.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Patients").HasKey(c => c.Id);
            //
            
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(15).IsRequired();

        }
    }
}