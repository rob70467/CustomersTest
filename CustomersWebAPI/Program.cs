using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using ServiceLayer;
using ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerDBContext>(options =>
    options.UseInMemoryDatabase("CustomerDatabase"));

// DI customer code
builder.Services.AddScoped<ICustomerData, CustomerData>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CustomerDBContext>();
    context.Database.EnsureCreated();  // This will apply the seeding
}
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
