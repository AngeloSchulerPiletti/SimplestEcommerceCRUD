using Microsoft.AspNetCore.JsonPatch;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.DTO;
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

        public PurchaseOrderGroupDto GetCustomerPurchases(int customerId)
        {
            Customer customer = _ecommerceContext.Customers.Find(customerId);
            if (customer == null) return null;

            List<int> customerPurchases = GetCustomerPurchasesIds(customerId);
            if (customerPurchases.Count == 0) return null;

            List<PurchaseItemDto> purchaseItemDtos = _ecommerceContext.ItemPurchases
                .Select(x => new PurchaseItemDto(x.Product, x.Quantity, x.PurchaseId))
                .ToList();

            List<PurchaseOrderDto> purchaseOrderDtoList = new();

            foreach(int index in customerPurchases)
            {
                List<PurchaseItemDto> tmpPurchaseItemDto = purchaseItemDtos.Where(x => x.PurchaseId == index).ToList();
                purchaseOrderDtoList.Add(new PurchaseOrderDto(tmpPurchaseItemDto));
            }

            return new PurchaseOrderGroupDto(purchaseOrderDtoList);
        }

        public object GetMostPurchasedProductsByClient(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            if (customer == null) return null;

            List<int> customerPurchases = GetCustomerPurchasesIds(customerId);

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

        private List<int> GetCustomerPurchasesIds(int customerId)
        {
            return _ecommerceContext.Purchases
                .Where(x => x.CustomerId == customerId)
                .OrderBy(x => x.Id)
                .Select(x => x.Id)
                .ToList();
        }
    }
}
