using Microsoft.AspNetCore.Mvc;
using Test.Customer.Application.Abstractions;
using Test.Customer.Application.Inputs;

namespace Test.Customer.Api.Controllers;

/// <summary>
/// Resource Customer
/// </summary>
[Route("[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerApplication _customerApplication;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="customerApplication"></param>
    public CustomerController(ICustomerApplication customerApplication) => _customerApplication = customerApplication;


    /// <summary>
    /// Get Customer
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
        Ok(await _customerApplication.GetAsync(id, cancellationToken));

    /// <summary>
    /// Get Customers
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default) =>
        Ok(await _customerApplication.GetAsync(cancellationToken));

    /// <summary>
    /// Update Customer
    /// </summary>
    /// <param name="customer"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateCustomerInput customer, CancellationToken cancellationToken = default) =>
        Ok(await _customerApplication.UpdateAsync(customer, cancellationToken));

    /// <summary>
    /// Create Customer
    /// </summary>
    /// <param name="input"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateCustomerInput input, CancellationToken cancellationToken = default) =>
        Ok(await _customerApplication.AddAsync(input, cancellationToken));

    /// <summary>
    /// Remove Customer
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken = default) =>
        Ok(await _customerApplication.RemoveAsync(id, cancellationToken));
}