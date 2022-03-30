using Microsoft.AspNetCore.JsonPatch;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Business.Interfaces
{
    public interface ICustomerBusiness
    {
        public ResponseVo CreateCustomer(Customer customer);
        public ResponseVo DeleteCustomer(int customerId);
        public ResponseVo GetCustomer(int customerId);
        public ResponseVo GetCustomerPurchases(int customerId);
        public ResponseVo GetMostPurchasedProductsByClient(int customerId);
        public ResponseVo UpdateCustomer(JsonPatchDocument customer, int customerId);
    }
}
