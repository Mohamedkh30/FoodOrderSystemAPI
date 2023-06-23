using AutoMapper;
using FoodOrderSystemAPI.BL.DTOs.Restaurants;
using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace FoodOrderSystemAPI.BL;

public class RestaurantManager : IRestaurantManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<RestaurantModel> _UserMangager;
    private readonly ICustomerManager _customerManager;
    private readonly IConfiguration _configuration;
    //private readonly IMapper _mapper;

    public RestaurantManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<RestaurantModel> UserMangager, ICustomerManager customerManager, IConfiguration configuration)
    {
        this._unitOfWork = unitOfWork;
        _UserMangager = UserMangager;
        _customerManager = customerManager;
        _configuration = configuration;
        //this._mapper = mapper;
    }

    public async Task<TokenDto> Login(CustomerToLogin NewLoginCustomer)
    {
        var Customer = await _UserMangager.FindByNameAsync(NewLoginCustomer.UserName);
        if (Customer is null || await _UserMangager.IsLockedOutAsync(Customer))
        {
            return null;
        }
        bool isAuthenticated = await _UserMangager.CheckPasswordAsync(Customer, NewLoginCustomer.Password);
        if (!isAuthenticated)
        {
            _UserMangager.AccessFailedAsync(Customer);
            return null;
        }

        var CustomerClaims = await _UserMangager.GetClaimsAsync(Customer);

        // Generate Tkey 
        var secretkey = _configuration["secretkey"];
        var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
        var key = new SymmetricSecurityKey(secretkeyinbytes);

        // Generate Hashing Result 
        var HashingResult = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //Generate JWt Token 
        // Calc Expiration Date 
        var ExpirationDate = DateTime.Now.AddMinutes(30);
        var Jwt = new JwtSecurityToken(
            claims: CustomerClaims,
            notBefore: DateTime.Now,
            expires: ExpirationDate,
            signingCredentials: HashingResult
            );

        var TokenHandler = new JwtSecurityTokenHandler();
        string TokenString = TokenHandler.WriteToken(Jwt);

        return new TokenDto()
        {
            Token = TokenString,
            ExpirationDate = ExpirationDate
        };
    }


    public List<RestaurantsReadDto> GetAllRestaurants()
    {
        var AllRestaurants = _unitOfWork.Restaurants.GetAll();
        //return _mapper.Map<List<RestaurantsReadDto>>(AllRestaurants);
        return AllRestaurants.Select(r => new RestaurantsReadDto()
        {
            RestaurantName = r.RestaurantName,
            Address = r.Address,
            Logo = r.Logo,
            Phone = r.Phone,
            PaymentMethods = r.PaymentMethods
        }).ToList();
    }

    public List<RestaurantsProductsReadDto> GetAllRestaurantsWithProducts()
    {
        var AllRestaurantsWithProducts = _unitOfWork.Restaurants.GetRestaurantsWithProducts();
        //return _mapper.Map<List<RestaurantsProductsReadDto>>(AllRestaurantsWithProducts);
        return AllRestaurantsWithProducts.Select(r =>new RestaurantsProductsReadDto()
        {
            RestaurantName = r.RestaurantName,
            Address = r.Address,
            Logo = r.Logo,
            Phone = r.Phone,
            PaymentMethods = r.PaymentMethods,
            Products = r.Products
        }).ToList();
    }

    public RestaurantDetailsDto? GetRestaurantDetailsById(int id)
    {
        var RestaurantDetails = _unitOfWork.Restaurants.GetById(id);
        if (RestaurantDetails == null)
        {
            return null;
        }
        //return _mapper.Map<RestaurantDetailsDto>(RestaurantDetails);
        return new RestaurantDetailsDto()
        {
            RestaurantName = RestaurantDetails.RestaurantName,
            Address = RestaurantDetails.Address,
            Logo = RestaurantDetails.Logo,
            Phone = RestaurantDetails.Phone,
            PaymentMethods = RestaurantDetails.PaymentMethods
        };
    }

    public RestaurantProductsDto? GetRestaurentWithProductsById(int id)
    {
        var RestaurantProducts = _unitOfWork.Restaurants.GetRestaurantProductsById(id);
        if (RestaurantProducts == null)
        {
            return null;
        }
        //return _mapper.Map<RestaurantProductsDto>(RestaurantProducts);
        return new RestaurantProductsDto()
        {
            Products = RestaurantProducts.ToList()
        };
    }

    public RestaurantPaymentMethodDto? GetRestaurantPaymentMethodsById(int id)
    {
        var RestaurantPaymentMethod = _unitOfWork.Restaurants.GetById(id);
        if(RestaurantPaymentMethod == null) { return null; }
        //return _mapper.Map<RestaurantPaymentMethodDto>(RestaurantPaymentMethod);
        return new RestaurantPaymentMethodDto()
        {
            RestaurantName = RestaurantPaymentMethod.RestaurantName,
            PaymentMethods = RestaurantPaymentMethod.PaymentMethods
        };
    }

    public async Task<TokenDto> AddRestaurant(RestaurantAddDto restaurantDto)
    {
        //var NewRestaurant = _mapper.Map<RestaurantModel>(restaurantDto);
        var NewRestaurant = new RestaurantModel()
        {
            RestaurantName = restaurantDto.RestaurantName,
            Address = restaurantDto.Address,
            Logo = restaurantDto.Logo,
            Phone = restaurantDto.Phone,
            PaymentMethods = restaurantDto.PaymentMethods,
            Email = restaurantDto.Email,
            Role = RoleOptions.Resturant,
            UserName = restaurantDto.UserName
        };
        var CreationResult = await _UserMangager.CreateAsync(NewRestaurant, restaurantDto.Password);


        // Add To Table 
        if (CreationResult.Succeeded)
        {
            var RestaurantClaims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name, NewRestaurant.UserName),
                new Claim(ClaimTypes.Email, NewRestaurant.Email),
                new Claim(ClaimTypes.NameIdentifier, NewRestaurant.Id.ToString()),
                new Claim(ClaimTypes.Role, NewRestaurant.Role.ToString())
            };

            await _UserMangager.AddClaimsAsync(NewRestaurant, RestaurantClaims);
            //_unitOfWork.Customers.Add(CustomerToAdd);
            _unitOfWork.Save();
            // Instantiate An New User to Login from the user that Register
            CustomerToLogin RegisteredCustomerToLogin = new CustomerToLogin()
            {
                UserName = NewRestaurant.UserName,
                Password = restaurantDto.Password
            };
            return await Login(RegisteredCustomerToLogin);

        }
        else if (!CreationResult.Succeeded)
        {
            // The user creation operation returned errors
            // Inspect the errors and handle them accordingly
            foreach (var error in CreationResult.Errors)
            {
                // Access the error properties
                var errorCode = error.Code;
                var errorMessage = error.Description;

                // Log or handle the error message
            }
        }
            return null;
        //_unitOfWork.Restaurants.Add(NewRestaurant);
        //_unitOfWork.Save();
        //return NewRestaurant.Id;
    }

    public UpdateStatusEnum UpdateRestaurant(RestaurantUpdateDto restaurantDto)
    {
        var RestaurantUpdate = _unitOfWork.Restaurants.GetById(restaurantDto.Id);
        if (RestaurantUpdate == null)
        {
            return UpdateStatusEnum.NotFound;
        }
        //_mapper.Map(restaurantDto, RestaurantUpdate);
        RestaurantUpdate.RestaurantName = restaurantDto.RestaurantName;
        RestaurantUpdate.Address = restaurantDto.Address;
        RestaurantUpdate.Logo = restaurantDto.Logo;
        RestaurantUpdate.Phone = restaurantDto.Phone;
        RestaurantUpdate.PaymentMethods = restaurantDto.PaymentMethods;
        _unitOfWork.Restaurants.Update(RestaurantUpdate);
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
