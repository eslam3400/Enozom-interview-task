using Microsoft.EntityFrameworkCore;
using Task.Repositories;
using TaskModels;

var builder = WebApplication.CreateBuilder(args);
var MySqlConnectionString = builder.Configuration.GetConnectionString("MySql");
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(MySqlConnectionString, ServerVersion.AutoDetect(MySqlConnectionString)));
builder.Services.AddScoped<IRepository<Hotel>, HotelRepository>();
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
