using InstaChef;
using InstaChef.Repository;
using InstaChef.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAccountServices, AccountServices>();
builder.Services.AddTransient<IBrowseServices, BrowseServices>();
builder.Services.AddTransient<IRecipeServices, RecipeServices>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

//builder.Services.AddSingleton(new JwtService("your-secret-key", "your-issuer", "your-audience"));     //later nlng ni

builder.Services.AddDbContext<InstaChefDbContext>(
        db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
    );

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
