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

        [HttpPost]
        [Route("new")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {

            return Ok();
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {

            return Ok();
        }
    }
}
