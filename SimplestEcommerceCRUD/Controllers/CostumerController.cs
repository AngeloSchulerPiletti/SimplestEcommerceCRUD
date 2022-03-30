using Microsoft.AspNetCore.Mvc;
using SimplestEcommerceCRUD.Domain.Entities;

namespace SimplestEcommerceCRUD.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/costumer/")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        [HttpGet]
        [Route("{costumerId}")]
        public IActionResult GetCostumer([FromQuery] int costumerId)
        {

            return Ok();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateCostumer([FromBody] Costumer costumer)
        {

            return Ok();
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateCostumer([FromBody] Costumer costumer)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{costumerId}")]
        public IActionResult DeleteCostumer([FromQuery] int costumerId)
        {

            return Ok();
        }
    }
}
