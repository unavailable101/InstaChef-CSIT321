using InstaChef.Repository;
using InstaChef.Services;
using InstaChef;
using Microsoft.EntityFrameworkCore;
using InstaChef.Repositories;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAccountServices, AccountServices>();
builder.Services.AddTransient<IBrowseServices, BrowseServices>();
builder.Services.AddTransient<IRecipeServices, RecipeServices>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

// Added this
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ChefRecipesService>();
builder.Services.AddTransient<IChefRecipesRepository, ChefRecipesRepository>();

//builder.Services.AddScoped<IChefRecipesRepository, ChefRecipesRepository>();
//builder.Services.AddScoped<IChefRecipesService, ChefRecipesService>();

//builder.Services.AddSingleton(new JwtService("your-secret-key", "your-issuer", "your-audience"));     //later nlng ni


builder.Services.AddDbContext<InstaChefDbContext>(
        db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
    );

//builder.Services.AddDbContext<SQLiteDbContext>();

//builder.Services.AddScoped<IDataMigrationService, DataMigrationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5286") // Frontend URL
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Optional: Allow credentials if needed
        });
});

var app = builder.Build();

app.MapControllers(); // This maps controller routes to the appropriate actions

// Middleware setup
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Data")),
    RequestPath = "/Data"
});

app.UseRouting(); // Important: Before UseCors()
app.UseCors("AllowFrontend"); // Apply CORS policy
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

// Fallback for SPA (optional)
app.MapFallbackToFile("index.html");

app.Run();