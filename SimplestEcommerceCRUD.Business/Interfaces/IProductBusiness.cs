using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface IProductBusiness
    {
        public ResponseVo GetProduct(int productId);
    }
}
