using hw_2.WebApi;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(typeof(UsersMapProfile).Assembly);
builder.Services.AddControllers();
builder.Services.AddSingleton<IGetUserCommand, GetUsersCommand>();
builder.Services.AddTransient<IUserMapDto, UserMapDto>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();