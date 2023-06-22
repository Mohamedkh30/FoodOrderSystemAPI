using FoodOrderSystemAPI.BL.DTOs.Restaurants;

namespace FoodOrderSystemAPI.BL;

public interface IRestaurantManager
{
    List<RestaurantsReadDto> GetAllRestaurants();
    RestaurantDetailsDto? GetRestaurantDetailsById(int id);
    List<RestaurantsProductsReadDto> GetAllRestaurantsWithProducts();
    RestaurantPaymentMethodDto? GetRestaurantPaymentMethodsById(int id);
    RestaurantProductsDto? GetRestaurentWithProductsById(int id);
    int AddRestaurant(RestaurantAddDto restaurantDto);
    UpdateStatusEnum UpdateRestaurant(RestaurantUpdateDto restaurantDto);
    DeleteStatusEnum DeleteRestaurant(int id);
}