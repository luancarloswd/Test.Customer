using AutoMapper;

namespace Test.Customer.Application.Inputs.Profiles;

public class UpdateCustomerProfile : Profile
{
    public UpdateCustomerProfile() => CreateMap<UpdateCustomerInput, Domain.Customer>();
}