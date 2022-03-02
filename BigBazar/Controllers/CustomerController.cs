using BigBazarAPI;
using BigBazarModels.Models;
using BigBazarService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static List<Customer> listc = new List<Customer>();
        private readonly ICustomerService _customerService;

        private readonly AppSettings _appsettings;
        AuthTokenConfig tac = new AuthTokenConfig();
        public CustomerController(ICustomerService customerService, IOptions<AppSettings> appsettings)
        {
            _customerService = customerService;
            _appsettings = appsettings.Value;

        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public SecurityTokenDTOC Authenticate(string username, string password)
        {
           
                var child = _customerService.getchild(username, password);

            if (child == null)
            {
                /*MemberAccessException memberAccessException = new MemberAccessException("Wrong Credentials");
                throw memberAccessException;*/
               // throw new InvalidOperationException(nameof(child));
               // throw new NullReferenceException();
                return null;
            }

            var token = GetAccessTokenAsyncC(child);
           

            return token.Result;
        }
        // GET: api/<CustomerController>
        [Authorize]
        [HttpGet]
        public List<Customer> Get()
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            return _customerService.GetCustomerS();
        }

        // GET api/<CustomerController>/5
        [Authorize]
        [HttpGet("{id}")]
        public List<Customer> Get(int id)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            return _customerService.GetCustomerS(id);
        }

        // POST api/<CustomerController>
        [Authorize]
        [HttpPost]
        public List<Customer> Post(int Id, string Name, string Email, string custMobile, int itemid, string itemname, string itemtype, int itemqty)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);

            var obj = new Customer() { customerId = Id, customerName = Name, customerEmail = Email, customerMobile = custMobile, itemId = itemid, itemName = itemname, itemQty = itemqty, itemType = itemtype };
            _customerService.InsertCustomerS(obj);
            return listc;

        }

        // PUT api/<CustomerController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id,string Name, string Email, string custMobile, int itemid, string itemname, string itemtype, int itemqty)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            var obj = new Customer() { customerId = id, customerName = Name, customerEmail = Email, customerMobile = custMobile, itemId = itemid, itemName = itemname, itemQty = itemqty, itemType = itemtype };
            _customerService.UpdateCustomerS(id,obj);
        }

    // DELETE api/<CustomerController>/5
    [Authorize]
    [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            _customerService.DeleteCustomerS(id);
        }

        #region Private Internal Section

        private async Task<SecurityTokenDTOC> GetAccessTokenAsyncC(ChildC childDto)
        {
            //Exception Handling 
            if(childDto == null)
            {
                throw new ArgumentNullException("Wrong credentials");
                
            }
            List<Claim> clientClaims = new List<Claim>();

                clientClaims.Add(new Claim(TokenAuthClaims.UserId.Type, childDto.Id.ToString()));

            clientClaims.Add(new Claim("Name", childDto.childname));

            var token = await tac.GenerateJwtTokenAsyncC(childDto, _appsettings, clientClaims);


            var securityTokenDto = new SecurityTokenDTOC()
            {
                authToken = token,
                userName = childDto.childname
            };

            return securityTokenDto;
        }

        #endregion
    }
}
