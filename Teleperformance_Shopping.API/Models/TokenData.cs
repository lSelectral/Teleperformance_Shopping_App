namespace Teleperformance_Shopping.API.Models
{
    public class TokenData
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Expiration { get; set; }
    }
}