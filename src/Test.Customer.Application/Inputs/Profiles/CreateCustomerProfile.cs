using AutoMapper;

namespace Test.Customer.Application.Inputs.Profiles;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerInput, Domain.Customer>();
    }
}