using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/purchase/")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        [HttpGet]
        [Route("{purchaseId}")]
        public IActionResult GetPurchase([FromQuery] int purchaseId)
        {

            return Ok();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreatePurchase([FromBody] Purchase purchase)
        {

            return Ok();
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdatePurchase([FromBody] Purchase purchase)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{purchaseId}")]
        public IActionResult DeletePurchase([FromQuery] int purchaseId)
        {

            return Ok();
        }
    }
}
