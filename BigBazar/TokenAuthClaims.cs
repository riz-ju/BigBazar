using System.Security.Claims;

namespace BigBazarAPI
{
    public class TokenAuthClaims
    {
        public static Claim TokenId = new Claim(nameof(TokenId), false.ToString());
        public static Claim UserId = new Claim(nameof(UserId), false.ToString());
        public static Claim ExpirationDate = new Claim(nameof(ExpirationDate), false.ToString());
        public static Claim EmailId = new Claim(nameof(EmailId), false.ToString());
        public static Claim ClientId = new Claim(nameof(ClientId), false.ToString());
        public static Claim Secret = new Claim(nameof(Secret), false.ToString());
        public static Claim Host = new Claim(nameof(Host), false.ToString());
    }
}
