using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Product GetProduct(int productId);
    }
}
