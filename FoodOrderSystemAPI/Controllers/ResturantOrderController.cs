using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantOrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<OrderResturntReadDto> GetAllOrdersByResturanId()
        {

        }
    }
}
