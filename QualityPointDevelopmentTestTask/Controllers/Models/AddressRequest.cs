namespace QualityPointDevelopmentTestTask.Controllers.Models;

using AutoMapper;

public class AddressRequest
{
    public string[]? Addresses { get; set; }
}

public class AddressRequestProfile : Profile
{
    public AddressRequestProfile()
    {
        CreateMap<string, AddressRequest>()
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new[] { src }));
    }
}
