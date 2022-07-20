namespace Test.Customer.Infrastructure.Abstractions;

public interface ICustomerRepository
{
    Task<Domain.Customer?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Domain.Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Domain.Customer> UpdateAsync(Domain.Customer customer, CancellationToken cancellationToken = default);
    Task<Domain.Customer> AddAsync(Domain.Customer customer, CancellationToken cancellationToken = default);
    Task<Domain.Customer> RemoveAsync(Domain.Customer customer, CancellationToken cancellationToken = default);
}