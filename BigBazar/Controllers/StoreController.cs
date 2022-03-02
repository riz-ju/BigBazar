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
    public class StoreController : ControllerBase
    {
        static List<Store> lists = new List<Store>();
        private readonly IStoreService _storeService;
       
       
        private readonly AppSettings _appsettings;
        AuthTokenConfig tac = new AuthTokenConfig();
        public StoreController(IStoreService storeService, IOptions<AppSettings> appsettings)
        {
            _storeService = storeService;
            _appsettings = appsettings.Value;

        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public SecurityTokenDTO Authenticate(string username, string password)
        {

            var child = _storeService.getchild(username, password);
            //Exception handling
            if (child == null)
            {

                return null;
            }
            var token = GetAccessTokenAsync(child);
            return token.Result;
        }
        // GET: api/<StoreController>
        [Authorize]
        [HttpGet]
        public List<Store> Get()
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            return _storeService.GetStoreS();
        }

        // GET api/<StoreController>/5
        [Authorize]
        [HttpGet("item/{Count}")]
        public List<Store> Get(int Count)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            return _storeService.GetStoreS(Count);  
        }

        // POST api/<StoreController>
        [Authorize]
        [HttpPost]
        public List<Store> Post(IFormFile file)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            if (file.FileName.EndsWith(".csv"))
            {
                var sreader = new StreamReader(file.OpenReadStream());
                while (!sreader.EndOfStream)
                {
                    string[] rows = sreader.ReadLine().Split(',');

                    int Id = int.Parse(rows[0]);
                    string Name = rows[1];
                    string Type = rows[2];
                    int Price = int.Parse(rows[3]);
                    int Quantity = int.Parse(rows[4]);

                    lists.Add(new Store { itemIdS = Id, itemNameS = Name, itemTypeS = Type, itemPriceS = Price, itemQuantityS = Quantity });

                }
            }
            _storeService.InsertStoreS(lists);
            return lists;

        }

        // PUT api/<StoreController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, string itemname, string itemtype, int itemprice, int itemquantity)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            // lists.Add(new Store { itemIdS = id, itemNameS = itemname, itemTypeS = itemtype, itemPriceS = itemprice, itemQuantityS = itemquantity });
            _storeService.UpdateStoreS(id, itemname, itemtype, itemprice, itemquantity);
        }


        // DELETE api/<StoreController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            _storeService.DeleteStoreS(id);
        }

        #region Private Internal Section

        private async Task<SecurityTokenDTO> GetAccessTokenAsync(Child childDto)
        {
            //Exception Handling 
            if (childDto == null)
            {
                throw new ArgumentNullException("Wrong credentials");

            }

            List<Claim> clientClaims = new List<Claim>();

            clientClaims.Add(new Claim(TokenAuthClaims.UserId.Type, childDto.Id.ToString()));
            clientClaims.Add(new Claim("Name", childDto.childname));


            var token = await tac.GenerateJwtTokenAsync(childDto, _appsettings, clientClaims);


            var securityTokenDto = new SecurityTokenDTO()
            {
                authToken = token,
                userName = childDto.childname
            };

            return securityTokenDto;
        }

        #endregion
    }
}
