using QualityPointDevelopmentTestTask;
using QualityPointDevelopmentTestTask.Configuration;
using QualityPointDevelopmentTestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
services.Configure<DadataConfiguration>(configuration.GetSection(DadataConfiguration.Configuration));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddHttpClient();
services.AddHttpClient("DadataApi", (sp, client)=>
{
    var dadataConfiguration = sp.GetConfiguration<DadataConfiguration>();
    client.BaseAddress = new Uri(dadataConfiguration.Url);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Authorization", dadataConfiguration.Token);
    client.DefaultRequestHeaders.Add("X-Secret", dadataConfiguration.SecretKey);
});

services.AddControllers();

services.RegisterAppServices();

services.AddAppCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAppMiddlewares();

app.UseAppCors();

await app.RunAsync();
