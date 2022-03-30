using Microsoft.EntityFrameworkCore;
using SimplestEcommerceCRUD.Business;
using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Repository;
using SimplestEcommerceCRUD.Repository.Database.Context;
using SimplestEcommerceCRUD.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiVersioning();

builder.Services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
