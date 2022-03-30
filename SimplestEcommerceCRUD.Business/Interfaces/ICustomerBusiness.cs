using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        public ResponseVo GetCustomer(int customerId);
    }
}
