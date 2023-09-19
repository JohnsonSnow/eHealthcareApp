using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eHealthcare.Data;
using eHealthcare.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<eHealthcareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("eHealthcareContext") ?? throw new InvalidOperationException("Connection string 'eHealthcareContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200");
}));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapHub<BroadcastHub>("/nofity");
app.MapControllers();

app.Run();
