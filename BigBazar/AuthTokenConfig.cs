using BigBazarModels.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BigBazarAPI
{
    public class AuthTokenConfig
    {
        //Child Generator token
        public async Task<string> GenerateJwtTokenAsync(Child user, AppSettings appSettings, List<Claim> claims)
        {
            //Create the token id claim
            Claim tokenIdClaim = new Claim(TokenAuthClaims.TokenId.Type, Guid.NewGuid().ToString());

            //Create the expiration date claim
            Claim expirationDateClaim = new Claim(TokenAuthClaims.ExpirationDate.Type,
                                       DateTime.Now.AddMinutes(appSettings.TokenDuration).ToString());

            var expirationDate = DateTime.Parse(expirationDateClaim.Value);

            claims.Add(tokenIdClaim);
            //claims.Add(new Claim(TokenAuthClaims.UserId.Type, user.Id.ToString()));
            claims.Add(new Claim(TokenAuthClaims.Secret.Type, appSettings.SecurityKey));
            claims.Add(expirationDateClaim);

            //main lines for create token
            //below


            //Generate the JWT credentials.
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecurityKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Set here jwt security token parameters.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: appSettings.Issuer,
                audience: appSettings.Audience,
                claims: claims,
                expires: expirationDate, //Token expires every month.  This means user has to relogin every month.
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            //above

        }


        
        //ChildC token generator
        public async Task<string> GenerateJwtTokenAsyncC(ChildC user, AppSettings appSettings, List<Claim> claims)
        {
            //Create the token id claim
            Claim tokenIdClaim = new Claim(TokenAuthClaims.TokenId.Type, Guid.NewGuid().ToString());

            //Create the expiration date claim
            Claim expirationDateClaim = new Claim(TokenAuthClaims.ExpirationDate.Type,
                                       DateTime.Now.AddMinutes(appSettings.TokenDuration).ToString());

            var expirationDate = DateTime.Parse(expirationDateClaim.Value);

            claims.Add(tokenIdClaim);
            //claims.Add(new Claim(TokenAuthClaims.UserId.Type, user.Id.ToString()));
            claims.Add(new Claim(TokenAuthClaims.Secret.Type, appSettings.SecurityKey));
            claims.Add(expirationDateClaim);

            //main lines for create token
            //below


            //Generate the JWT credentials.
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecurityKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Set here jwt security token parameters.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: appSettings.Issuer,
                audience: appSettings.Audience,
                claims: claims,
                expires: expirationDate, //Token expires every month.  This means user has to relogin every month.
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            //above

        }


        //ChildW token generator
        public async Task<string> GenerateJwtTokenAsyncW(ChildW user, AppSettings appSettings, List<Claim> claims)
        {
            //Create the token id claim
            Claim tokenIdClaim = new Claim(TokenAuthClaims.TokenId.Type, Guid.NewGuid().ToString());

            //Create the expiration date claim
            Claim expirationDateClaim = new Claim(TokenAuthClaims.ExpirationDate.Type,
                                       DateTime.Now.AddMinutes(appSettings.TokenDuration).ToString());

            var expirationDate = DateTime.Parse(expirationDateClaim.Value);

            claims.Add(tokenIdClaim);
            //claims.Add(new Claim(TokenAuthClaims.UserId.Type, user.Id.ToString()));
            claims.Add(new Claim(TokenAuthClaims.Secret.Type, appSettings.SecurityKey));
            claims.Add(expirationDateClaim);

            //main lines for create token
            //below


            //Generate the JWT credentials.
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecurityKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Set here jwt security token parameters.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: appSettings.Issuer,
                audience: appSettings.Audience,
                claims: claims,
                expires: expirationDate, //Token expires every month.  This means user has to relogin every month.
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            //above

        }

        //Validate Token Claims
        public async Task<Dictionary<string, string>> ValidateToken(string token, AppSettings appSettings)
        {
            token = token.ToString().Split(' ')[1];
            Dictionary<string, string> claimsData = new Dictionary<string, string>();
            ClaimsIdentity identity = null;

            ClaimsPrincipal principal = await GetPrincipal(token, appSettings);
            if (principal == null)
            {
                return claimsData;
            }

            identity = (ClaimsIdentity)principal?.Identity;
            if (identity == null)
            {
                return claimsData;
            }

            List<Claim> claims = identity?.Claims.ToList();
            claims?.ForEach(x => claimsData.Add(x.Type, x.Value));

            return claimsData;
        }


        private async Task<ClaimsPrincipal> GetPrincipal(string token, AppSettings appSettings)
        {
            //main lines for validate token
            //below
            byte[] key = Encoding.ASCII.GetBytes(appSettings.SecurityKey);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            //above


            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = appSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = appSettings.Audience,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };
            return await Task.FromResult(tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken));
        }

      
    }
}
