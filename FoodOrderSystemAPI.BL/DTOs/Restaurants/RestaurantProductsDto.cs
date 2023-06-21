namespace FoodOrderSystemAPI.BL.DTOs.Restaurants
{
    public class RestaurantProductsDto
    {
        public ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();
    }
}