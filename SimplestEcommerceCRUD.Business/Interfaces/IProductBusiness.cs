using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface IProductBusiness
    {
        public ResponseVo CreateProduct(Product product);
        public ResponseVo DeleteProduct(int productId);
        public ResponseVo GetProduct(int productId);
        public ResponseVo GetProductPurchases(int productId);
    }
}
