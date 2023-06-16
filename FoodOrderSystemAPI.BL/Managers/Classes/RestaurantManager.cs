using AutoMapper;
using FoodOrderSystemAPI.BL.DTOs.Restaurants;
using FoodOrderSystemAPI.DAL;

namespace FoodOrderSystemAPI.BL;

public class RestaurantManager : IRestaurantManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RestaurantManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    public List<RestaurantsReadDto> GetAllRestaurants()
    {
        var AllRestaurants = _unitOfWork.Restaurants.GetAll();
        return _mapper.Map<List<RestaurantsReadDto>>(AllRestaurants);
    }

    public List<RestaurantsProductsReadDto> GetAllRestaurantsWithProducts()
    {
        var AllRestaurantsWithProducts = _unitOfWork.Restaurants.GetRestaurantsWithProducts();
        return _mapper.Map<List<RestaurantsProductsReadDto>>(AllRestaurantsWithProducts);
    }

    public RestaurantDetailsDto? GetRestaurantDetailsById(int id)
    {
        var RestaurantDetails = _unitOfWork.Restaurants.GetById(id);
        if (RestaurantDetails == null)
        {
            return null;
        }
        return _mapper.Map<RestaurantDetailsDto>(RestaurantDetails);
    }

    public RestaurantProductsDto? GetRestaurentWithProductsById(int id)
    {
        var RestaurantProducts = _unitOfWork.Restaurants.GetRestaurantProductsById(id);
        if (RestaurantProducts == null)
        {
            return null;
        }
        return _mapper.Map<RestaurantProductsDto>(RestaurantProducts);
    }

    public RestaurantPaymentMethodDto? GetRestaurantPaymentMethodsById(int id)
    {
        var RestaurantPaymentMethod = _unitOfWork.Restaurants.GetById(id);
        if(RestaurantPaymentMethod == null) { return null; }
        return _mapper.Map<RestaurantPaymentMethodDto>(RestaurantPaymentMethod);
    }

    public int AddRestaurant(RestaurantAddDto restaurantDto)
    {
        var NewRestaurant = _mapper.Map<RestaurantModel>(restaurantDto);
        _unitOfWork.Restaurants.Add(NewRestaurant);
        _unitOfWork.Save();
        return NewRestaurant.Id;
    }

    public UpdateStatusEnum UpdateRestaurant(RestaurantUpdateDto restaurantDto)
    {
        var RestaurantUpdate = _unitOfWork.Restaurants.GetById(restaurantDto.Id);
        if (RestaurantUpdate == null)
        {
            return UpdateStatusEnum.NotFound;
        }
        _mapper.Map(restaurantDto, RestaurantUpdate);
        _unitOfWork.Save();
        return UpdateStatusEnum.Successfull;
    }

    public DeleteStatusEnum DeleteRestaurant(int id)
    {
        var RestaurantDelete = _unitOfWork.Restaurants.GetById(id);
        if (RestaurantDelete == null) { return DeleteStatusEnum.NotFound; }
        _unitOfWork.Restaurants.Delete(RestaurantDelete);
        _unitOfWork.Save();
        return DeleteStatusEnum.Successfull;
    }
}
