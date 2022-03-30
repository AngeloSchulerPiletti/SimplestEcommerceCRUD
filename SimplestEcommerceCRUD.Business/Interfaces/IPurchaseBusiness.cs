using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface IPurchaseBusiness
    {
        public ResponseVo CreatePurchase(Purchase purchase);
        public ResponseVo DeletePurchase(int purchaseId);
        public ResponseVo GetPurchase(int purchaseId);
    }
}
