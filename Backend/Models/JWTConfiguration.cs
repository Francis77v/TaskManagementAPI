using System.Globalization;

namespace Backend.Models;

public class JWTConfiguration
{
    public string Issuer { get; } = string.Empty;

    public string Secret { get; } = string.Empty;

    public string Audience { get; } = string.Empty;

    public int ExpireDays { get; }

    public JWTConfiguration(IConfiguration configuration)
    {
        var section = configuration.GetSection("JWT");

        Issuer = section[nameof(Issuer)];
        Secret = section[nameof(Secret)];
        Audience = section[nameof(Secret)];
        ExpireDays = Convert.ToInt32(section[nameof(ExpireDays)], CultureInfo.InvariantCulture);
    }
}