using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;
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

        public Customer CreateCustomer(Customer customer)
        {
            _ecommerceContext.Customers.Add(customer);
            _ecommerceContext.SaveChanges();
            return customer;
        }

        public Customer GetCustomer(int customerId)
        {
            return _ecommerceContext.Customers.FirstOrDefault(x => x.Id == customerId);
        }
    }
}
