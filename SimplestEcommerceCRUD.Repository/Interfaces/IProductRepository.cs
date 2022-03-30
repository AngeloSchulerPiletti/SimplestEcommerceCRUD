using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Product CreateProduct(Product product);
        public bool DeleteProduct(int productId);
        public Product GetProduct(int productId);
    }
}
