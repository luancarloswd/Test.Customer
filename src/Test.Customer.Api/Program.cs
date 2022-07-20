using Microsoft.EntityFrameworkCore;
using Test.Customer.Application;
using Test.Customer.Application.Abstractions;
using Test.Customer.Application.Inputs.Profiles;
using Test.Customer.Infrastructure.Abstractions;
using Test.Customer.Infrastructure.Context;
using Test.Customer.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TestCustomerContext>(opt =>
    opt.UseInMemoryDatabase("Customers"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(CreateCustomerProfile).Assembly));
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();