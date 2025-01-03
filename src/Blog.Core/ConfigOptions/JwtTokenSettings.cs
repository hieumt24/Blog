namespace Blog.Core.ConfigOptions;

public class JwtTokenSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public int ExpiryInHours { get; set; }
}