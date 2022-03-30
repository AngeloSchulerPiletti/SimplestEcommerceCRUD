using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.DTO;
using SimplestEcommerceCRUD.Repository.Database.Context;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly EcommerceContext _ecommerceContext;

        public PurchaseRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Purchase GetPurchase(int purchaseId)
        {
            return _ecommerceContext.Purchases.FirstOrDefault(x => x.Id == purchaseId);
        }

        public PurchaseOrderDto CreatePurchase(Purchase purchase)
        {
            _ecommerceContext.Purchases.Add(purchase);
            _ecommerceContext.SaveChanges();

            List<PurchaseItemDto> purchaseItemsDto = new();
            foreach (ItemPurchase itemPurchase in purchase.ItemPurchases)
            {
                Product product = _ecommerceContext.Products.Find(itemPurchase.ProductId);
                purchaseItemsDto.Add(new PurchaseItemDto(product, itemPurchase.Quantity));
            }
            return new PurchaseOrderDto(purchaseItemsDto);
        }

        public bool DeletePurchase(int purchaseId)
        {
            Purchase purchase = GetPurchase(purchaseId);
            if (purchase == null) return false;

            _ecommerceContext.Purchases.Remove(purchase);
            _ecommerceContext.SaveChanges();
            return true;
        }
    }
}
