using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.DTO;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        public PurchaseOrderDto CreatePurchase(Purchase purchase);
        public bool DeletePurchase(int purchaseId);
        public Purchase GetPurchase(int purchaseId);
    }
}
