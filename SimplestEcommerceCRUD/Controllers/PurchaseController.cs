using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/purchase/")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseBusiness _business;

        public PurchaseController(IPurchaseBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("{purchaseId}")]
        public IActionResult GetPurchase(int purchaseId)
        {
            ResponseVo response = _business.GetPurchase(purchaseId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreatePurchase([FromBody] Purchase purchase)
        {
            ResponseVo response = _business.CreatePurchase(purchase);
            return response.IsError ? BadRequest(response) : Ok(response);
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdatePurchase([FromBody] Purchase purchase)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{purchaseId}")]
        public IActionResult DeletePurchase(int purchaseId)
        {
            ResponseVo response = _business.DeletePurchase(purchaseId);
            return response.IsError ? BadRequest(response) : Ok(response);
        }
    }
}
