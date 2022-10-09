using Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebApiDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDbContextConnection"));
});

builder.Services.AddTransient<ICheckEmail, CheckEmail>();
builder.Services.AddTransient<ICheckPhonenumber, CheckPhonenumber>();
builder.Services.AddTransient<ICheckBankAccountNumber, CheckBankAccountNumber>();
builder.Services.AddTransient<ICheckUnique, CheckUnique>();

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
