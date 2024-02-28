using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeFileReader>();
builder.Services.AddOutputCache();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();
app.UseHttpsRedirection();

app.MapGet("/employee", FindEmployeeByIdRequestHandler)
.WithName("FindEmployeeById")
.WithOpenApi()
.CacheOutput();

app.Run();


// improve your api:
// add output caching (https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-8.0)
// add error handling

Employee? FindEmployeeByIdRequestHandler([FromServices]EmployeeService service, [FromQuery]int  id)
{
    var employee = service.FindEmployee(id);
    return employee;
}