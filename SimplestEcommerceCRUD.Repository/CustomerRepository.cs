using Microsoft.AspNetCore.JsonPatch;
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

        public Customer CreateCustomer(Customer customer)
        {
            _ecommerceContext.Customers.Add(customer);
            _ecommerceContext.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            if (customer == null) return false;

            _ecommerceContext.Customers.Remove(customer);
            _ecommerceContext.SaveChanges();
            return true;
        }

        public Customer GetCustomer(int customerId)
        {
            return _ecommerceContext.Customers.Find(customerId);
        }

        public object GetMostPurchasedProductsByClient(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            if (customer == null) return null;

            List<int> customerPurchases = _ecommerceContext.Purchases.Where(x => x.CustomerId == customerId).Select(x => x.Id ).ToList();

            var customerItemPurchases =
                _ecommerceContext.ItemPurchases
                    .Where(x => customerPurchases.Contains(x.PurchaseId)) // Pode tá errado
                    .GroupBy(x => x.ProductId)
                    .Select(x => new
                    {
                        ProductId = x.Key,
                        Count = x.Sum(s => s.Quantity),
                    })
                    .OrderByDescending(x => x.Count)
                    .Take(5);

            return customerItemPurchases;

        }

        public Customer UpdateCustomer(JsonPatchDocument customer, int customerId)
        {
            Customer currentCustomer = GetCustomer(customerId);
            if (currentCustomer == null) return null;

            customer.ApplyTo(currentCustomer);
            _ecommerceContext.SaveChanges();
            return currentCustomer;
        }
    }
}
