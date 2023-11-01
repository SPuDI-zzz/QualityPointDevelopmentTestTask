namespace QualityPointDevelopmentTestTask.Services;

using QualityPointDevelopmentTestTask.Controllers.Models;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAddress(AddressRequest address);
}
