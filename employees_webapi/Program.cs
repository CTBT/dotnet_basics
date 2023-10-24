using EmployeeCore.IO;
using EmployeeCore.Repositories;
using employees_webapi.Configuration;
using employees_webapi.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOptions<ServiceOptions>();
builder.Services.AddSingleton<EmployeeRepo>();

ServiceOptions serviceOptions = new ServiceOptions();
builder.Configuration.GetSection("ServiceOptions").Bind(serviceOptions);

if (serviceOptions.TestData)
{
    builder.Services.AddSingleton<IEmployeeDataReader, EmployeeTestDataReader>();
}
else
{
    builder.Services.AddSingleton<IEmployeeDataReader, EmployeeDataReader>(); 
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();