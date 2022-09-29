using CrudApp.Services;
using CrudApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var env = builder.Environment;

// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
// Configure DI
services.AddScoped<IUserService, UserService>();
// Add DB Context
services.AddDbContext<UserContext>();

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
