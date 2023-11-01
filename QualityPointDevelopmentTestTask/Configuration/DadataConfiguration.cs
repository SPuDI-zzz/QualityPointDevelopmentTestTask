namespace QualityPointDevelopmentTestTask.Configuration;

public class DadataConfiguration
{
    public const string Configuration = "DadataConfiguration";
    public string Url { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
}
