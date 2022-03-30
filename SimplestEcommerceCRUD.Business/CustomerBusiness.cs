using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepository _repository;

        public CustomerBusiness(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ResponseVo GetCustomer(int customerId)
        {
            Customer customer = _repository.GetCustomer(customerId);
            if (customer == null) return new ResponseVo("Customer not found", $"The customer of id {customerId} were not found");
            return new ResponseBagVo<Customer>(customer, "Customer found", "The customer were found succesfully", false);
        }
    }
}
