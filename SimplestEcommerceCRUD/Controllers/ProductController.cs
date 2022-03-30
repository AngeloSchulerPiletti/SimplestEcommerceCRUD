using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct(int productId)
        {

            return Ok();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateProduct([FromBody] Product product)
        {

            return Ok();
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

            return Ok();
        }
    }
}
