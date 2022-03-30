using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Business
{
    public class PurchaseBusiness : IPurchaseBusiness
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseBusiness(IPurchaseRepository repository)
        {
            _repository = repository;
        }

        public ResponseVo GetPurchase(int purchaseId)
        {
            Purchase purchase = _repository.GetPurchase(purchaseId);
            if (purchase == null) return new ResponseVo("Purchase not found", $"The purchase of id {purchaseId} were not found");
            return new ResponseBagVo<Purchase>(purchase, "Purchase found", "The purchase were found succesfully", false);
        }
    }
}
