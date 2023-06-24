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
        //[Authorize]

        public ActionResult<List<ProductCardDto>> GetAll()
        {
            return _productManager.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize]

        public ActionResult<ProductCardDto> GetById(int id)
        {
            ProductCardDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<int> Add(ProductAddDto product)
        {
            var addresult =  _productManager.Add(product);
            if (addresult == 0)
                return BadRequest(0);
            return Ok(addresult);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            ProductCardDto? product = _productManager.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            _productManager.delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(ProductCardDto product)
        {
            _productManager.update(product);
            return NoContent();
        }


    }
}
