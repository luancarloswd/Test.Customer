using Microsoft.EntityFrameworkCore;
using Test.Customer.Infrastructure.Abstractions;
using Test.Customer.Infrastructure.Context;

namespace Test.Customer.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly TestCustomerContext _context;

    public CustomerRepository(TestCustomerContext context) => _context = context;

    public Task<Domain.Customer?> GetAsync(Guid id, CancellationToken cancellationToken = default) => 
        _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task<List<Domain.Customer>> GetAllAsync(CancellationToken cancellationToken = default) => 
        _context.Customers.ToListAsync(cancellationToken);

    public async Task<Domain.Customer> UpdateAsync(Domain.Customer customer, CancellationToken cancellationToken = default)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return customer;
    }

    public async Task<Domain.Customer> AddAsync(Domain.Customer customer, CancellationToken cancellationToken = default)
    {
        await _context.Customers.AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return customer;
    }

    public async Task<Domain.Customer> RemoveAsync(Domain.Customer customer, CancellationToken cancellationToken = default)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return customer;
    }
}