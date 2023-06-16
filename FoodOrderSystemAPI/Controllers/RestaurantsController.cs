using FoodOrderSystemAPI.BL;
using FoodOrderSystemAPI.BL.DTOs.Restaurants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantManager _restaurantManager;

        public RestaurantsController(IRestaurantManager restaurantManager)
        {
            this._restaurantManager = restaurantManager;
        }

        [HttpGet]
        public ActionResult<List<RestaurantsReadDto>> GetAll()
        {
            var Resturants = _restaurantManager.GetAllRestaurants();
            if (!Resturants.Any())
            {
                return NotFound();
            }
            return Resturants;
        }

        [HttpGet]
        [Route("Products")]
        public ActionResult<List<RestaurantsProductsReadDto>> GetAllWithProjects()
        {
            var RestaurantsWithProducts =  _restaurantManager.GetAllRestaurantsWithProducts();
            if (!RestaurantsWithProducts.Any()) { return NotFound(); }
            return RestaurantsWithProducts;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<RestaurantDetailsDto> GetById(int id)
        {
            var Restaurant = _restaurantManager.GetRestaurantDetailsById(id);
            if (Restaurant == null)
            {
                return NotFound();
            }
            return Restaurant;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<RestaurantProductsDto> GetProducts(int id)
        {
            var RestaurantProducts = _restaurantManager.GetRestaurentWithProductsById(id);
            if (RestaurantProducts == null)
            {
                return NotFound();
            }
            return RestaurantProducts;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<RestaurantPaymentMethodDto> GetPaymentMethod(int id)
        {
            var RestaurantPaymentMethod = _restaurantManager.GetRestaurantPaymentMethodsById(id);
            if (RestaurantPaymentMethod == null)
            {
                return NotFound();
            }
            return RestaurantPaymentMethod;
        }

        [HttpPost]
        public ActionResult Add(RestaurantAddDto restaurantAddDto)
        {
            var IdOfRestaurantAdded = _restaurantManager.AddRestaurant(restaurantAddDto);
            return CreatedAtAction("GetById", new { id = IdOfRestaurantAdded });
        }

        [HttpPut]
        public ActionResult<UpdateStatusEnum> Update(RestaurantUpdateDto restaurantUpdateDto)
        {
            var ResultOfUpdate = _restaurantManager.UpdateRestaurant(restaurantUpdateDto);
            if (ResultOfUpdate == UpdateStatusEnum.NotFound)
            {
                return NotFound();
            }
            else if (ResultOfUpdate == UpdateStatusEnum.InvalidInput) { return BadRequest(); }
            return ResultOfUpdate;
        }

        [HttpDelete]
        public ActionResult<DeleteStatusEnum> Delete(int id)
        {
            var ResultOfDelete = _restaurantManager.DeleteRestaurant(id);
            if (ResultOfDelete == DeleteStatusEnum.NotFound) { return NotFound(); }
            return ResultOfDelete;
        }
    }
}
