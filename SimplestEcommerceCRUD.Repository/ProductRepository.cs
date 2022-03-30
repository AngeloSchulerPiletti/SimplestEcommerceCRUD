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
            return _ecommerceContext.Products.Find(productId);
        }

        public ProductPurchasesDto GetProductPurchases(int productId)
        {
            Product product = GetProduct(productId);

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

        public List<ProductPurchasesDto> GetProductPurchases()
        {
            List<int> productIds = _ecommerceContext.Products.OrderByDescending(x => x.Id).Select(x => x.Id).ToList();

            if (productIds.Count == 0) return null;

            List<ProductPurchasesDto> purchaseItemDtos = new();

            foreach (int productId in productIds)
            {
                Product product = GetProduct(productId);

                ProductPurchasesDto productPurchasesDto = _ecommerceContext.ItemPurchases
                    .Where(x => x.ProductId == productId)
                    .GroupBy(x => x.ProductId)
                    .Select(x => new ProductPurchasesDto(product, x.Sum(x => x.Quantity), (int)(x.Sum(x => x.Quantity) * product.Price)))
                    .First();

                purchaseItemDtos.Add(productPurchasesDto);
            }

            return purchaseItemDtos;

        }
    }
}
