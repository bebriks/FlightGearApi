using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using webapi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "YFlight Gear API",
        Description = "Flight Gear simulation WebAPI."
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("https://localhost:44409")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddExceptionHandler<FlightGearExceptionHandler>();
builder.Services.TryAddApplicationLayer();
builder.Services.TryAddInfrastructure();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use the defined CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();