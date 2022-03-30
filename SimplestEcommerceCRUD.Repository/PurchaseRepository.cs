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
    }
}
