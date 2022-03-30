using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        public Purchase GetPurchase(int purchaseId);
    }
}
