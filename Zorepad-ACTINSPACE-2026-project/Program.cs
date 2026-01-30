using Microsoft.EntityFrameworkCore;
using Zorepad_ACTINSPACE_2026_project;
using Zorepad_ACTINSPACE_2026_project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var connectionString = "Host=172.16.41.78;Port=5432;Database=cosmic_db;Username=admin;Password=<secret_password>";

// register DbContext BEFORE calling Build()
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();