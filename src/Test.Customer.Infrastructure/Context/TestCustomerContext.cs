using Microsoft.EntityFrameworkCore;

namespace Test.Customer.Infrastructure.Context;

public class TestCustomerContext : DbContext
{
    public TestCustomerContext(DbContextOptions<TestCustomerContext> options) : base(options)
    {
    }

    public DbSet<Domain.Customer> Customers { get; set; }
}