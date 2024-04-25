namespace Backend.Service.Configurations.Jwt
{
    public class JwtOptions
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string SecretKey { get; init; }
        public double TokenLifetimeInDays { get; init; }
    }
}
