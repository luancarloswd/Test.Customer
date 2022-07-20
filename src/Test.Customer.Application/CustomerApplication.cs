using AutoMapper;
using Test.Customer.Application.Abstractions;
using Test.Customer.Application.Inputs;
using Test.Customer.Application.Outputs;
using Test.Customer.Infrastructure.Abstractions;

namespace Test.Customer.Application;

public class CustomerApplication : ICustomerApplication
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerApplication(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerOutput?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<CustomerOutput?>(customer);
    }

    public async Task<List<CustomerOutput>> GetAsync(CancellationToken cancellationToken = default)
    {
        var customers = await _customerRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CustomerOutput>>(customers);
    }

    public async Task<CustomerOutput> UpdateAsync(UpdateCustomerInput input, CancellationToken cancellationToken = default)
    {
        var customer = _mapper.Map<Domain.Customer>(input);
        customer = await _customerRepository.UpdateAsync(customer, cancellationToken);
        return _mapper.Map<CustomerOutput>(customer);
    }

    public async Task<CustomerOutput> AddAsync(CreateCustomerInput input, CancellationToken cancellationToken = default)
    {
        var customer = _mapper.Map<Domain.Customer>(input);
        customer = await _customerRepository.AddAsync(customer, cancellationToken);

        return _mapper.Map<CustomerOutput>(customer);
    }

    public async Task<CustomerOutput?> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetAsync(id, cancellationToken);
        if (customer == default) return default;

        await _customerRepository.RemoveAsync(customer, cancellationToken);
        return _mapper.Map<CustomerOutput>(customer);
    }
}