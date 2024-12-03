using ServerAPI.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IShoppingRepository, ShoppingRepositoryInMemory>();
builder.Services.AddSingleton<IToDoRepository, ToDoRepositoryInMemory>();
builder.Services.AddSingleton<IWeatherRepo, WeatherRepo>();
builder.Services.AddSingleton<ILoginRepository, LoginRepositorySQLite>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

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
app.UseCors("policy");
app.UseAuthorization();

app.MapControllers();

app.Run();