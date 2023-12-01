using hw_2.WebApi;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserCommand, UserCommand>();
builder.Services.AddTransient<IValidator<UserCreateDto>, UserCreateValidator>();
builder.Services.AddTransient<IUserMapDto, UserMapDto>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();