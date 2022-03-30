using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/customer/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _business;

        public CustomerController(ICustomerBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetCustomer(int customerId)
        {
            ResponseVo response = _business.GetCustomer(customerId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpGet]
        [Route("most-purchased/{customerId}")]
        public IActionResult GetMostPurchasedProductsByClient(int customerId)
        {
            ResponseVo response = _business.GetMostPurchasedProductsByClient(customerId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            ResponseVo response = _business.CreateCustomer(customer);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPatch]
        [Route("update/{customerId}")]
        public IActionResult UpdateCustomer([FromBody] JsonPatchDocument customer, int customerId)
        {
            ResponseVo response = _business.UpdateCustomer(customer, customerId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpDelete]
        [Route("delete/{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            ResponseVo response = _business.DeleteCustomer(customerId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }
    }
}
