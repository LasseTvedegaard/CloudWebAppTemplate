using Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Force correct Azure port binding
// ======================
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// ======================
// Database configuration
// ======================
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("Connection string 'DefaultConnection' not found.");

builder.Services.AddScoped<IConnection>(_ =>
    new Connection(connectionString));

builder.Services.AddScoped(
    typeof(IGenericConnection<>),
    typeof(GenericConnection<>)
);

// ======================
// Services
// ======================
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "CloudWebApp API", Version = "v1" });
});

var app = builder.Build();

// ======================
// Middleware
// ======================

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudWebApp API V1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();

app.MapControllers();

app.Run();
