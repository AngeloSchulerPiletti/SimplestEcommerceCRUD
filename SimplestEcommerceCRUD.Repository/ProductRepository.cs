using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.DTO;
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

        public ProductPurchasesDto GetProductPurchases(int productId)
        {
            Product product = _ecommerceContext.Products.Find(productId);

            List<PurchaseItemDto> purchaseItemDtos = _ecommerceContext.ItemPurchases
                .Where(x => x.ProductId == productId)
                .Select(x => new PurchaseItemDto(x.Product, x.Quantity, x.PurchaseId))
                .ToList();

            if (purchaseItemDtos.Count == 0) return null;

            ProductPurchasesDto productPurchases = new(product);

            foreach (PurchaseItemDto purchaseItemDto in purchaseItemDtos)
            {
                productPurchases.Quantity += purchaseItemDto.Quantity;
            }

            productPurchases.CalculateTotal();

            return productPurchases;
        }
    }
}
