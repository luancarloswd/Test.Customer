using AutoMapper;

namespace Test.Customer.Application.Outputs.Profiles;

public class CustomerOutputProfile : Profile
{
    public CustomerOutputProfile()
    {
        CreateMap<Domain.Customer, CustomerOutput>();
    }
}