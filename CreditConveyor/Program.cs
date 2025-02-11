using CreditConveyor.DbLayer;
using CreditConveyor.Interfaces;
using CreditConveyor.Repositories.Interfaces;
using CreditConveyor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddTransient(typeof(IBaseCRUDDataService<>), typeof(BaseCRUDDataService<>));
builder.Services.AddTransient<ICallRepository, CallRepository>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<ICreditProductRepository, CreditProductRepository>();
builder.Services.AddTransient<ICreditApplicationRepository, CreditApplicationRepository>();
builder.Services.AddTransient<ICallDataService, CallDataService>();
builder.Services.AddTransient<IClientDataService, ClientDataService>();
builder.Services.AddTransient<ICreditApplicationDataService, CreditApplicationDataService>();
builder.Services.AddTransient<ICreditProductDataService, CreditProductDataService>();
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
