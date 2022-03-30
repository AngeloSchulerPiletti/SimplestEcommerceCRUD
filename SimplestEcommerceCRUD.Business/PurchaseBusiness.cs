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

        public ResponseVo CreatePurchase(Purchase purchase)
        {
            try
            {
                Purchase savedPurchase = _repository.CreatePurchase(purchase);
                if (savedPurchase == null) return new ResponseVo("Purchase not saved", "The purchase could not be saved");
                return new ResponseBagVo<Purchase>(savedPurchase, "Purchase saved", "The purchase was saved succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Purchase not saved", "Database problem");
            }
        }

        public ResponseVo DeletePurchase(int purchaseId)
        {
            try
            {
                bool result = _repository.DeletePurchase(purchaseId);
                if (result) return new ResponseVo("Purchase deleted", "The purchase was deleted successfully", false);
                return new ResponseVo("Purchase not deleted", "The purchase couldn't be deleted");
            }
            catch (Exception)
            {
                return new ResponseVo("Purchase not saved", "Database problem");
            }
        }

        public ResponseVo GetPurchase(int purchaseId)
        {
            Purchase purchase = _repository.GetPurchase(purchaseId);
            if (purchase == null) return new ResponseVo("Purchase not found", $"The purchase of id {purchaseId} were not found");
            return new ResponseBagVo<Purchase>(purchase, "Purchase found", "The purchase were found succesfully", false);
        }
    }
}
