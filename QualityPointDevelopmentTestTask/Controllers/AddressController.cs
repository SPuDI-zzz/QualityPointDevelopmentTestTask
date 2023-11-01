namespace QualityPointDevelopmentTestTask.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QualityPointDevelopmentTestTask.Controllers.Models;
using QualityPointDevelopmentTestTask.Services;

[Route("api/dadata")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;

    public AddressController(IAddressService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IEnumerable<AddressResponse>> GetAddress([FromQuery]string address)
    {
        var arrAddresses = _mapper.Map<AddressRequest>(address);
        var addressDtos = await _addressService.GetAddress(arrAddresses);
        var response = _mapper.Map<IEnumerable<AddressResponse>>(addressDtos);

        return response;
    }
}
