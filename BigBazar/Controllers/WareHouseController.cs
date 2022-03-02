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
    public class WareHouseController : ControllerBase
    {
      
          static List<WareHouse> listwh = new List<WareHouse>();
        private readonly IWareHouseService _wareHouseService;

        private readonly AppSettings _appsettings;
        AuthTokenConfig tac = new AuthTokenConfig();
        public WareHouseController(IWareHouseService wareHouseService, IOptions<AppSettings> appsettings)
        {
            _wareHouseService = wareHouseService;
            _appsettings = appsettings.Value;

                
        }
        [AllowAnonymous]
        [HttpGet("authenticate")]
        public SecurityTokenDTOW Authenticate(string username, string password)
        {

            var child = _wareHouseService.getchild(username, password);
            //Exception handling
            if (child == null)
            {
                
                return null;
            }

            var token = GetAccessTokenAsyncW(child);


            return token.Result;
        }
        // GET: api/<WareHouseController>
        [Authorize]
        [HttpGet]
        public List<WareHouse> Get()
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            return _wareHouseService.GetWareHouseS();
        }

    /*    // GET api/<WareHouseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<WareHouseController>
        [Authorize]
        [HttpPost]
        public List<WareHouse> Post(IFormFile file)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            if (file.FileName.EndsWith(".csv"))
            {
                var sreader = new StreamReader(file.OpenReadStream());
                while (!sreader.EndOfStream)
                {
                    String[] rows = sreader.ReadLine().Split(',');

                    int Id = int.Parse(rows[0]);
                    string Name = rows[1];
                    string Type = rows[2];
                    int Price = int.Parse(rows[3]);
                    int Quantity = int.Parse(rows[4]);
                    
                    listwh.Add(new WareHouse { itemIdW = Id, itemNameW = Name, itemTypeW = Type,itemPriceW = Price, itemQuantityW = Quantity });

                }
            }
            _wareHouseService.InsertWareHouseS(listwh);
            return listwh;
        }

        // PUT api/<WareHouseController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id,string itemname, string itemtype, int itemprice, int itemquantity)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            //listwh.Add(new WareHouse { itemIdW = id, itemNameW = itemname, itemTypeW = itemtype, itemPriceW = itemprice, itemQuantityW = itemquantity });
            _wareHouseService.UpdateWareHouseS(id,itemname,itemtype,itemprice,itemquantity);
        }

        // DELETE api/<WareHouseController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var validatedtoken = tac.ValidateToken(Request.Headers["Authorization"], _appsettings);
            _wareHouseService.DeleteWareHouseS(id);
        }

        #region Private Internal Section

        private async Task<SecurityTokenDTOW> GetAccessTokenAsyncW(ChildW childDto)
        {
            //Exception Handling 
            if (childDto == null)
            {
                throw new ArgumentNullException("Wrong credentials");

            }

            List<Claim> clientClaims = new List<Claim>();

            clientClaims.Add(new Claim(TokenAuthClaims.UserId.Type, childDto.Id.ToString()));
            clientClaims.Add(new Claim("Name", childDto.childname));


            var token = await tac.GenerateJwtTokenAsyncW(childDto, _appsettings, clientClaims);


            var securityTokenDto = new SecurityTokenDTOW()
            {
                authToken = token,
                userName = childDto.childname
            };

            return securityTokenDto;
        }

        #endregion
    }
}
