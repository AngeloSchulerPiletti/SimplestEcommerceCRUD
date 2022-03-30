using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Repository.Database.Context;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceContext _ecommerceContext;

        public CustomerRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public Customer GetCustomer(int customerId)
        {
            return _ecommerceContext.Customers.FirstOrDefault(x => x.Id == customerId);
        }
    }
}
