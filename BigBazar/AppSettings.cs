namespace BigBazarAPI
{
    public class AppSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
        public int TokenDuration { get; set; }
    }
}
