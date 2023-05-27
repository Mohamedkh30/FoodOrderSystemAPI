using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerManager:ICustomerManager

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<CustomerModel> _UserMangager;
    private readonly IConfiguration _configuration;

    public CustomerManager(IUnitOfWork unitOfWork , UserManager <CustomerModel> UserMangager , IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _UserMangager = UserMangager;
       _configuration = configuration;
    }

    public List<CustomerModel> Delete()
    {
        throw new NotImplementedException();
    }

    public List<CustomerModel> GetAllCutomers()
    {
        
        return _unitOfWork.Customers.GetAllWithNavProp().ToList();

    }

    public List<CustomerModel> GetById()
    {
        throw new NotImplementedException();
    }

    public async Task<int> Register(CustomerToRegister RegisterdCustomer)
    {
        // Map to CutomerModel To Add To List 

        var CustomerToAdd = new CustomerModel()
        {
            UserName = $"{RegisterdCustomer.FirstName}{RegisterdCustomer.LastName}",
            Email = RegisterdCustomer.Email,
            Role = RoleOptions.Customer,
            PhoneNumber = RegisterdCustomer.Phone,
            BirthDate = RegisterdCustomer.CustomerBirth,
            // Set Card
            CustomerCreditCard = new CreditCard()
            {
                Card_Number = RegisterdCustomer.CardNumber,
                Card_Expiration_Date = RegisterdCustomer.ExpirationDate,
                CVV = RegisterdCustomer.CvvNumber

            },

            // Set Address 
            CustomerAddress = new Location()
            {
                Longitude = RegisterdCustomer.Langitude,
                Latitude = RegisterdCustomer.Landitude,

            }
        };

        // Hashing The Password 
        var CreationResult = await _UserMangager.CreateAsync(CustomerToAdd, RegisterdCustomer.Password);

        // Add To Table 
        if (CreationResult.Succeeded)
        {
            var CustomerClaims = new List<Claim>()
            {

                new Claim(ClaimTypes.NameIdentifier, CustomerToAdd.UserName),
                new Claim(ClaimTypes.Email, CustomerToAdd.Email),
                new Claim(ClaimTypes.Role, CustomerToAdd.Role.ToString())
            };

            await _UserMangager.AddClaimsAsync(CustomerToAdd, CustomerClaims);
            _unitOfWork.Customers.Add(CustomerToAdd);
            _unitOfWork.Save();
            return CustomerToAdd.Id;
        }
        return -1;
    }



    public List<CustomerToRead> ReadAllCutomerProperties() {

      var CutomersToRead =  _unitOfWork.Customers.GetAllWithNavProp().Select(c => new CustomerToRead() {
          FullName = c.UserName,
          Email = c.Email,
          Role = c.Role.ToString(),
          Phone = c.PhoneNumber,
          CustomerBirth = c.BirthDate,
          // Set Card
         
           CardNumber = c.CustomerCreditCard.Card_Number,
           ExpirationDate = c.CustomerCreditCard.Card_Expiration_Date,
           CvvNumber = c.CustomerCreditCard.CVV,
          // Set Address 

          Longitude = c.CustomerAddress.Longitude,
          Latitude = c.CustomerAddress.Latitude

          });


        return CutomersToRead.ToList();


    }

    public async Task<string> Login(CustomerToLogin NewLoginCustomer )
    {
        var Customer =await _UserMangager.FindByNameAsync(NewLoginCustomer.UserName);
        if (Customer is null ||await  _UserMangager.IsLockedOutAsync(Customer))
        {
        return string.Empty;
        }
        bool isAuthenticated = await _UserMangager.CheckPasswordAsync(Customer , NewLoginCustomer.Password);
        if (! isAuthenticated ) {
        _UserMangager.AccessFailedAsync(Customer);
            return string.Empty;
        }

        var CustomerClaims = await _UserMangager.GetClaimsAsync(Customer);

        // Generate Tkey 
        var secretkey = _configuration["secretkey"];
        var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
        var key = new SymmetricSecurityKey(secretkeyinbytes);
       
        // Generate Hashing Result 
        var HashingResult = new SigningCredentials(key , SecurityAlgorithms.HmacSha256Signature);

        //Generate JWt Token 

        var Jwt = new JwtSecurityToken(
            claims: CustomerClaims,
            notBefore:DateTime.Now,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: HashingResult 
            );

        var TokenHandler = new JwtSecurityTokenHandler();
        string TokenString  = TokenHandler.WriteToken(Jwt);

        return TokenString;




    }

    public CreditToRead UpdateCardCutomerData(int Customerid, CreditToUpdate creditCard)
    {
        var DbCreditCard  = _unitOfWork.Customers.GetCustomerByIdWithNavprop(Customerid).CustomerCreditCard;
        if (DbCreditCard != null) {
            DbCreditCard.Card_Number = creditCard.Card_Number;
            DbCreditCard.Card_Expiration_Date = creditCard.Card_Expiration_Date;
            DbCreditCard.CVV = creditCard.CVV;
            _unitOfWork.Save();

        }
        return new CreditToRead() {CustomerId= DbCreditCard.CreditId ,
                    Card_Number = DbCreditCard.Card_Number,
            Card_Expiration_Date = DbCreditCard.Card_Expiration_Date,
            CVV = DbCreditCard.CVV
        };


    }

    public Location UpdateAddressCutomer(int Customerid, LocationToUpadate NewLocation)
    {
        var DbCustomerAddress  = _unitOfWork.Customers.GetCustomerByIdWithNavprop(Customerid).CustomerAddress;
        if (DbCustomerAddress != null)
        {
            DbCustomerAddress.Latitude = NewLocation.Latitude;
            DbCustomerAddress. Longitude= NewLocation.Longitude;
            _unitOfWork.Save();
        }
        return DbCustomerAddress;


    }

    public async Task< CustomerModel> UpdateCustomerPersonalData(int Customerid , CustomerToUpdatPersonalData UpdatedCustomer )
    {
       var DbCustomer =  _unitOfWork.Customers.GetById(Customerid);
        if (DbCustomer != null)
        {
            DbCustomer.PhoneNumber = UpdatedCustomer.Phone;
            DbCustomer.UserName = $"{UpdatedCustomer.FirstName}{UpdatedCustomer.LastName}";
            DbCustomer.Email = UpdatedCustomer.Email;
            DbCustomer.BirthDate = UpdatedCustomer.CustomerBirth;
            var newPasswordHash = _UserMangager.PasswordHasher.HashPassword(DbCustomer, UpdatedCustomer.Password);
            DbCustomer.PasswordHash = newPasswordHash;
            _unitOfWork.Save();
        }
        return DbCustomer;
    }

    public bool delete(int Customerid)
    {
        var deletedCustomer = _unitOfWork.Customers.GetById( Customerid);
        if (deletedCustomer != null) {
            _unitOfWork.Customers.Delete(deletedCustomer);
            return true;
        }
        return false;
    }
}
