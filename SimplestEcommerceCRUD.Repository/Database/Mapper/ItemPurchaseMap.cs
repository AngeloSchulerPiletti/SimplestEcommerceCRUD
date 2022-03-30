using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Database.Mapper
{
    public class ItemPurchaseMap : IEntityTypeConfiguration<ItemPurchase>
    {
        public void Configure(EntityTypeBuilder<ItemPurchase> builder)
        {
            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ItemPurchases)
                .HasForeignKey(x => x.ProductId);

            builder
                .HasOne(x => x.Purchase)
                .WithMany(x => x.ItemPurchases)
                .HasForeignKey(x => x.PurchaseId);
        }
    }
}
