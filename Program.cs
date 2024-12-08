using InstaChef;
using InstaChef.Repository;
using InstaChef.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAccountServices, AccountServices>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();


//builder.Services.AddDbContext<InstaChefDbContext>(
//        db => db.UseSqlServer(builder.Configuration.GetConnectionString("InstaChefDbConnectionString")), ServiceLifetime.Scoped
//    );
builder.Services.AddDbContext<InstaChefDbContext>(
        db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
    );
//builder.Services.AddDbContext<InstaChefDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
