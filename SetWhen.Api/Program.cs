using Carter;
using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;
using SetWhen.Infrastructure.Repositories;
using SetWhen.Infrastructure.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IReservationQueryService, ReservationQueryService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IStaffAvailabilityService, StaffAvailabilityService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateReservationCommand).Assembly));
builder.Services.AddCarter();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapCarter();

app.UseHttpsRedirection();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(dbContext); 
}


app.Run();
