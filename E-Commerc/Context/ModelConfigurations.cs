
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using global::E_Commerc.Entites;

    namespace E_Commerc.Configurations
    {
        public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
                builder.Property(c => c.Email).IsRequired();
                builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);
                builder.HasMany(c => c.Orders)
                       .WithOne(o => o.Customer)
                       .HasForeignKey(o => o.CustomerId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }

        public class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.HasKey(o => o.Id);
                builder.Property(o => o.OrderDate).IsRequired();
                builder.Property(o => o.TotalAmount).IsRequired();
            builder.Property(o => o.TotalAmount).HasPrecision(18, 2);

            builder.HasOne(o => o.Customer)
                       .WithMany(c => c.Orders)
                       .HasForeignKey(o => o.CustomerId)
                       .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(o => o.Payment)
                       .WithOne(p => p.Order)
                       .HasForeignKey<Payment>(p => p.OrderId);
                builder.HasOne(o => o.Shipping)
                       .WithOne(s => s.Order)
                       .HasForeignKey<Shipping>(s => s.OrderId);
            }
        }

        public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
        {
            public void Configure(EntityTypeBuilder<OrderDetail> builder)
            {
                builder.HasKey(od => od.Id);
                builder.Property(od => od.Quantity).IsRequired();
                builder.Property(od => od.UnitPrice).IsRequired();
            builder.Property(od => od.UnitPrice).HasPrecision(18, 2);

            builder.HasOne(od => od.Order)
                       .WithMany(o => o.OrderDetails)
                       .HasForeignKey(od => od.OrderId)
                       .OnDelete(DeleteBehavior.Cascade);
                builder.HasOne(od => od.Product)
                       .WithMany(p => p.OrderDetails)
                       .HasForeignKey(od => od.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }

        public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
        {
            public void Configure(EntityTypeBuilder<Shipping> builder)
            {
                builder.HasKey(s => s.Id);
                builder.Property(s => s.Address).IsRequired().HasMaxLength(200);
                builder.Property(s => s.ShippedDate).IsRequired();
            }
        }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Price).IsRequired();
                builder.Property(p => p.StockQuantity).IsRequired();
            }
        }

        public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
        {
            public void Configure(EntityTypeBuilder<Payment> builder)
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.PaymentMethod).IsRequired().HasMaxLength(50);
                builder.Property(p => p.IsPaid).IsRequired();
            }
        }
    }
