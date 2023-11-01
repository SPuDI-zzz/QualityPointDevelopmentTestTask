namespace QualityPointDevelopmentTestTask.Services;

using QualityPointDevelopmentTestTask.Controllers.Models;
using QualityPointDevelopmentTestTask.Exceptions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class AddressService : IAddressService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<AddressService> _logger;

    public AddressService(IHttpClientFactory httpClientFactory, ILogger<AddressService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<IEnumerable<AddressDto>> GetAddress(AddressRequest address)
    {
        var client = _httpClientFactory.CreateClient("DadataApi");
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Post;

        var jsonBody = JsonSerializer.Serialize(address.Addresses);
        message.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        _logger.LogInformation($"Send json body on server: {jsonBody}");
        var response = await client.SendAsync(message);

        if (!response.IsSuccessStatusCode)
        {
            var badRequestMessage = await response.Content.ReadAsStringAsync();
            _logger.LogWarning($"Bad request: {badRequestMessage}");
            throw new ProcessException("Bad request from DadataApi server");
        }

        var responseData = await response.Content.ReadFromJsonAsync<IEnumerable<AddressDto>>();
        return responseData!;
    }
}
