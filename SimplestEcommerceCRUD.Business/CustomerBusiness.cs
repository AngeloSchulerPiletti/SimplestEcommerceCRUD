using Microsoft.AspNetCore.JsonPatch;
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
                return new ResponseBagVo<Customer>(savedCustomer, "Customer saved", "The customer was saved succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }

        public ResponseVo DeleteCustomer(int customerId)
        {
            try
            {
                bool result = _repository.DeleteCustomer(customerId);
                if (result) return new ResponseVo("Customer deleted", "The customer was deleted successfully", false);
                return new ResponseVo("Customer not deleted", "The customer couldn't be deleted");
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
                if (customer == null) return new ResponseVo("Customer not found", $"The customer of id {customerId} was not found");
                return new ResponseBagVo<Customer>(customer, "Customer found", "The customer was found succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }

        public ResponseVo GetMostPurchasedProductsByClient(int customerId)
        {
            try
            {
                object mostPurchasedList = _repository.GetMostPurchasedProductsByClient(customerId);
                if (mostPurchasedList == null) return new ResponseVo("Couldn't resolve", $"Couldn't find most purchased items of customer {customerId}");
                return new ResponseBagVo<object>(mostPurchasedList, "Most purchased items found", "The customer's most purchased items were found succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }

        public ResponseVo UpdateCustomer(JsonPatchDocument customer, int customerId)
        {
            try
            {
                Customer updatedCustomer = _repository.UpdateCustomer(customer, customerId);
                if (updatedCustomer == null) return new ResponseVo("Customer not updated", $"The customer of id {customerId} couldn't be updated");
                return new ResponseBagVo<Customer>(updatedCustomer, "Customer updated", "The customer was updated succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Customer not saved", "Database problem");
            }
        }
    }
}
