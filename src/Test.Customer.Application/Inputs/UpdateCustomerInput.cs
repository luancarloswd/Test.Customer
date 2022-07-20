namespace Test.Customer.Application.Inputs;

public class UpdateCustomerInput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}