namespace NoqoodBooking.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JWTsettings";
    public string Secret { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public double ExpiryDurationInHoures { get; init; }
}
