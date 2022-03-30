using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        public Purchase CreatePurchase(Purchase purchase);
        public bool DeletePurchase(int purchaseId);
        public Purchase GetPurchase(int purchaseId);
    }
}
