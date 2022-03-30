using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface IPurchaseBusiness
    {
        public ResponseVo GetPurchase(int purchaseId);
    }
}
