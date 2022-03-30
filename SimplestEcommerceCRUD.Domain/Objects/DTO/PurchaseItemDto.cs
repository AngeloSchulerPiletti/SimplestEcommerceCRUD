using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Domain.Objects.DTO
{
    public class PurchaseItemDto
    {
        public PurchaseItemDto(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Total = (int)(product.Price * quantity);
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
