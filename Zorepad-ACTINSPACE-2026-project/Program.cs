using Microsoft.EntityFrameworkCore;
using Zorepad_ACTINSPACE_2026_project;
using Zorepad_ACTINSPACE_2026_project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

var connectionString = "Host=localhost;Port=5432;Database=stellar_library;Username=admin;Password=space_password_123";

//builder.Services.AddDbContext<AppDbContext>(options =>
  //  options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

app.Run();