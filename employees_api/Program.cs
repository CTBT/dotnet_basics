using System.Text.Json.Serialization;
using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeFileReader>();
builder.Services.AddOutputCache();
    

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();
app.UseHttpsRedirection();

app.MapGet("/employee/{id}", FindEmployeeByIdRequestHandler)
.WithName("FindEmployeeById")
.Produces<Employee>()
.WithOpenApi()
.CacheOutput();


app.MapGet("/employees", GetEmployees)
    .WithName("GetEmployees")
    .Produces<Employee>()
    .WithOpenApi()
    .CacheOutput();


app.Run();


// improve your api:
// add output caching (https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-8.0)
// work with http status codes
// add error handling

Results<NotFound, BadRequest, Ok<Employee>> FindEmployeeByIdRequestHandler([FromServices]EmployeeService service, [FromRoute]int  id)
{
    if (id < 0)
    {
        return TypedResults.BadRequest();
    }
    
    var employee = service.FindEmployee(id);

    return employee is not null ? TypedResults.Ok(employee) : TypedResults.NotFound();
}


Results<BadRequest<string>, Ok<IOrderedEnumerable<Employee>>> GetEmployees([FromServices]EmployeeService service, [FromQuery] int skillId, [FromQuery]Location location)
{
    if (service.GetSkills().All(i => i.Id != skillId))
    {
        return TypedResults.BadRequest("Skill filter is invalid");
    }
    
    var result = service.GetEmployees(skillId, location)
        .Take(100)
        .OrderBy(i => i.Name);

    return TypedResults.Ok(result);
}