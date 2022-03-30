using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _business;

        public ProductController(IProductBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            ResponseVo response = _business.GetProduct(productId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpGet]
        [Route("purchases/")]
        public IActionResult GetProductPurchases()
        {
            ResponseVo response = _business.GetProductPurchases();
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpGet]
        [Route("purchases/{productId}")]
        public IActionResult GetProductPurchases(int productId)
        {
            ResponseVo response = _business.GetProductPurchases(productId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            ResponseVo response = _business.CreateProduct(product);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            ResponseVo response = _business.DeleteProduct(productId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }
    }
}
