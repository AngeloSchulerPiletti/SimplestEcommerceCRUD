using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.DTO;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Product CreateProduct(Product product);
        public bool DeleteProduct(int productId);
        public Product GetProduct(int productId);
        public ProductPurchasesDto GetProductPurchases(int productId);
    }
}
