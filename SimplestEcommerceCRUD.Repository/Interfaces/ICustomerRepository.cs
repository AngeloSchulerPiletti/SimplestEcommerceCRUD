using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer);
        public Customer GetCustomer(int customerId);
    }
}
