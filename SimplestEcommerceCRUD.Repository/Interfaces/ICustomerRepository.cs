using Microsoft.AspNetCore.JsonPatch;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer);
        public bool DeleteCustomer(int customerId);
        public Customer GetCustomer(int customerId); 
        public object GetMostPurchasedProductsByClient(int customerId);
        public Customer UpdateCustomer(JsonPatchDocument customer, int customerId);
    }
}
