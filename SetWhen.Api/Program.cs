using Carter;
using SetWhen.Api.Extensions;
using SetWhen.Infrastructure.Configuration;
using SetWhen.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddOpenApi(); 
builder.Services.AddInfrastructure(builder.Configuration); 
builder.Services.AddAuth(builder.Configuration); 
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SetWhen.Application.Features.Reservations.Commands.CreateReservationCommand).Assembly));

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());


app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SetWhen.Infrastructure.Persistence.AppDbContext>();
    SetWhen.Infrastructure.Persistence.DbInitializer.Seed(dbContext);
}

app.Run();
