using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Domain.Objects.DTO
{
    public class ProductPurchasesDto
    {
        public ProductPurchasesDto(Product product, int quantity = 0, int total = 0)
        {
            Product = product;
            Quantity = quantity;
            Total = total;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

        public void CalculateTotal()
        {
            Total = (int)(Product.Price * Quantity);
        }
    }
}
