using FinancasApp.Infra.Data.Extensions;
using FinancasApp.Domain.Extensions;
using Scalar.AspNetCore;
using FinancasApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Métodos de extensão
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainService();

var app = builder.Build();

//Middlewares
app.UseMiddleware<ExceptionMiddleware>();

app.MapOpenApi();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

app.UseAuthorization();
app.MapControllers();
app.Run();
