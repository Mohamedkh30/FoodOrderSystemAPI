using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrderSystemAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager )
        {
            _customerManager = customerManager;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [Authorize("Customer")]
        public ActionResult<List<CustomerModel>> Get()
        {
         return Ok(_customerManager.ReadAllCutomerProperties());
        }

      

        // POST api/<CustomerController>
        [HttpPost]

        public async Task< int > Post(CustomerToRegister ResgiteredCustomer)
        {
            return await _customerManager.Register(ResgiteredCustomer);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(int id, CustomerToUpdatPersonalData CustomerPersonalData )
        {
          var CustomerUpdated = await  _customerManager.UpdateCustomerPersonalData(id, CustomerPersonalData);
            if (CustomerUpdated is null)
                return NoContent();
            return Ok(CustomerUpdated);
            
        }

        [HttpPatch()]
        [Route("Credit/{CustomerId}")]
        public ActionResult UpdateCredit(int CustomerId, CreditToUpdate CustomerCreditCard)
        {
            var CustomerCreditCardUpdated = _customerManager.UpdateCardCutomerData(CustomerId, CustomerCreditCard);
            if (CustomerCreditCardUpdated is null)
                return NoContent();
            return Ok(CustomerCreditCardUpdated);

        }


        [HttpPatch()]
        [Route("Location/{CustomerId}")]

        public ActionResult UpdateLocation(int CustomerId, LocationToUpadate CustomerAddress)
        {
            var CustomerUpdated = _customerManager.UpdateAddressCutomer(CustomerId, CustomerAddress);
            if (CustomerUpdated is null)
                return NoContent();
            return Ok(CustomerUpdated);

        }

        // DELETE api/<CustomerController>/5
        [HttpPost]
        [Route("/Login")]

        public async Task <ActionResult <string>>  Login_Presention_Layer(CustomerToLogin customerToLogin)
        {
            var LoginResult = await _customerManager.Login(customerToLogin);
            if(LoginResult == string.Empty) {
            return Unauthorized(LoginResult);
            }
            return Ok(LoginResult);
        }
        //// GET api/<CustomerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
