using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using RoutingDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cn = builder.Configuration.GetConnectionString("DefaultConn");
builder.Services.AddDbContext<HRContext>(options => options.UseSqlServer(cn));

//Add Api controller
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient();//passing data between controllers
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//Enables attribute routing

app.Run();
