using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Database.Mapper
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
