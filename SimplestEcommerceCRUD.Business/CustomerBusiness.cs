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

        public ResponseVo CreateCustomer(Customer customer)
        {
            try
            {
                Customer savedCustomer = _repository.CreateCustomer(customer);
                if (savedCustomer == null) return new ResponseVo("Customer not saved", "The customer could not be saved");
                return new ResponseBagVo<Customer>(savedCustomer, "Customer saved", "The customer were saved succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }

        public ResponseVo GetCustomer(int customerId)
        {
            try
            {
                Customer customer = _repository.GetCustomer(customerId);
                if (customer == null) return new ResponseVo("Customer not found", $"The customer of id {customerId} were not found");
                return new ResponseBagVo<Customer>(customer, "Customer found", "The customer were found succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }
    }
}
