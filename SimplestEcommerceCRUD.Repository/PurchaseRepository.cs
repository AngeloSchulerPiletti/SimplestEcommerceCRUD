using SimplestEcommerceCRUD.Domain.Entities;
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

        public Purchase CreatePurchase(Purchase purchase)
        {
            _ecommerceContext.Purchases.Add(purchase);
            _ecommerceContext.SaveChanges();
            return purchase;
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
