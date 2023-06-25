﻿using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantOrderController : ControllerBase
    {
        private readonly IRestaurantManager _ResturantMangager;
        public ResturantOrderController(IRestaurantManager resturantMangager)
        {
            _ResturantMangager = resturantMangager;
        }
        [HttpGet]
        public ActionResult<OrderResturntReadDto> GetAllOrdersByResturanId(int ResturnatId)
        {
            var orders = _ResturantMangager.GetOrdersByResturantId(ResturnatId);
            if (orders == null)
                return BadRequest();
            return Ok(orders);
        }
    }
}
