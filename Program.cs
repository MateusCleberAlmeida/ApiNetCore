using Microsoft.EntityFrameworkCore;
using PromoAPI.Data;
using PromoAPI.Data.Repository.Abstract;
using PromoAPI.Data.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;


builder.Services.AddDbContext<ApiDBContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

// Add services to the container.

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//app.UseEndpoints(endpoints => endpoints.MapControllers());

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
