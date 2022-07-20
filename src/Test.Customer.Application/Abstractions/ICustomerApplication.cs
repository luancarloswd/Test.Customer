using Test.Customer.Application.Inputs;
using Test.Customer.Application.Outputs;

namespace Test.Customer.Application.Abstractions;

public interface ICustomerApplication
{
    Task<CustomerOutput?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<CustomerOutput>> GetAsync(CancellationToken cancellationToken = default);
    Task<CustomerOutput> UpdateAsync(UpdateCustomerInput input, CancellationToken cancellationToken = default);
    Task<CustomerOutput> AddAsync(CreateCustomerInput input, CancellationToken cancellationToken = default);
    Task<CustomerOutput?> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}