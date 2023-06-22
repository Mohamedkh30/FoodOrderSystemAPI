namespace FoodOrderSystemAPI.BL.DTOs.Restaurants
{
    public class RestaurantsProductsReadDto
    {
        public string RestaurantName { set; get; } = string.Empty;
        public string Address { set; get; } = string.Empty;
        public string Logo { set; get; } = string.Empty;
        public string Phone { set; get; } = string.Empty;
        public string PaymentMethods { set; get; } = string.Empty;
        public ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();
    }
}