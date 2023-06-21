namespace FoodOrderSystemAPI.BL;

public class RestaurantsReadDto
{
    public string RestaurantName { set; get; } = string.Empty;
    public string Address { set; get; } = string.Empty;
    public string Logo { set; get; } = string.Empty;
    public string Phone { set; get; } = string.Empty;
    public string PaymentMethods { set; get; } = string.Empty;
}
