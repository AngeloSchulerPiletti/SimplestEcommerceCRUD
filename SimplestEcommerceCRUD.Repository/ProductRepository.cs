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

        public Product CreateProduct(Product product)
        {
            _ecommerceContext.Products.Add(product);
            _ecommerceContext.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int productId)
        {
            Product product = GetProduct(productId);
            if (product == null) return false;

            _ecommerceContext.Products.Remove(product);
            _ecommerceContext.SaveChanges();
            return true;
        }

        public Product GetProduct(int productId)
        {
            return _ecommerceContext.Products.FirstOrDefault(x => x.Id == productId);
        }
    }
}
