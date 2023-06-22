using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [Authorize]

        public ActionResult<List<FullProductDto>> GetAll()
        {
            return _productManager.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]

        public ActionResult<FullProductDto> GetById(int id)
        {
            FullProductDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<int> Add(FullProductDto product)
        {
            return _productManager.Add(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            FullProductDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            _productManager.delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(FullProductDto product)
        {
            _productManager.update(product);
            return NoContent();
        }


    }
}
