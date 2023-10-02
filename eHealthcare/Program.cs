using Microsoft.EntityFrameworkCore;
using eHealthcare.Data;
using eHealthcare.Services;
using eHealthcare.Repositories;
using eHealthcare.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Database={dbName};User Id=sa;Password={dbPassword};Persist Security Info=True;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=false;";
builder.Services.AddDbContext<eHealthcareContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ILoggingService, LoggingService>();

builder.Services.AddScoped<IActiveIngredientService, ActiveIngredientService>();
builder.Services.AddScoped<IActiveIngredientRepository, ActiveIngredientRepository>();

builder.Services.AddScoped<IProductUnitRepository, ProductUnitRepository>();
builder.Services.AddScoped<IProductUnitService, ProductUnitService>();

builder.Services.AddScoped<IAtcCodeRepository, AtcCodeRepository>();
builder.Services.AddScoped<IAtcCodeService, AtcCodeService>();

builder.Services.AddScoped<IPharmaceuticalFormRepository, PharmaceuticalFormRepository>();
builder.Services.AddScoped<IPharmaceuticalFormService, PharmaceuticalFormService>();

builder.Services.AddScoped<ITherapeuticalClassRepository, TherapeuticalClassRepository>();
builder.Services.AddScoped<ITherapeuticalClassService, TherapeuticalClassService>();

builder.Services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
{
    builder
    .WithOrigins("https://localhost:4200", "http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
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

app.MapHub<BroadcastHub>("notify");
app.MapControllers();

app.Run();
