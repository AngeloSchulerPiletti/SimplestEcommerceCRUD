using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Repository.Database.Context;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _ecommerceContext;

        public ProductRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Product GetProduct(int productId)
        {
            return _ecommerceContext.Products.FirstOrDefault(x => x.Id == productId);
        }
    }
}
