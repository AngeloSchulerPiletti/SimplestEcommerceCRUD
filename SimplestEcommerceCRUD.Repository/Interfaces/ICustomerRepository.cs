using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int customerId);
    }
}
