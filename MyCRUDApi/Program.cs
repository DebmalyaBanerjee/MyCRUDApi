var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Add Configuration for SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ 2. Register AppDbContext with Entity Framework Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ 3. Register Repositories (DI)
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// ✅ 4. Register MediatR
builder.Services.AddMediatR(typeof(GetAllProductsQueryHandler).Assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
