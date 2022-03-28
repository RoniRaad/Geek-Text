using Geek_Text;
using Geek_Text.Models;
using Geek_Text.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<CommentRepository>();
builder.Services.AddSingleton<RatingRepository>();
builder.Services.AddSingleton<DatabaseConfig>(serviceProvider =>
{
    var databaseConfig = new DatabaseConfig();
    databaseConfig.ConnectionString = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("Database");

    return databaseConfig;
});

var app = builder.Build();

var dbContext = app.Services.GetRequiredService<DatabaseContext>();
dbContext.SeedDatabase();

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
