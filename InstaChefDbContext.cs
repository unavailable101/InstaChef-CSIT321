using InstaChef.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaChef
{
    public class InstaChefDbContext : DbContext
    {
        public InstaChefDbContext(DbContextOptions<InstaChefDbContext> options) : base(options) { }

        //register tables
        public DbSet<Account> Account { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Pantry> Pantry { get; set; }


        //temporary data siguro, built-in bha
        // ayy basta oi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    FirstName = "Niña Margarette",
                    LastName = "Catubig",
                    Username = "cuteko",
                    Email = "marga18nins@gmail.com",
                    Password = "testing",
                    Status = 1
                },
                new Account
                {
                    Id = 2,
                    FirstName = "Francis Benedict",
                    LastName = "Chavez",
                    Username = "benedict",
                    Email = "francischavez@gmail.com",
                    Password = "testing2",
                    Status = 1
                },
                new Account
                {
                    Id = 3,
                    FirstName = "Paul Thomas",
                    LastName = "Abellana",
                    Username = "thomas",
                    Email = "paulabellana@gmail.com",
                    Password = "testing3",
                    Status = 1
                },
                new Account
                {
                    Id = 4,
                    FirstName = "Moriel",
                    LastName = "Bien",
                    Username = "bien",
                    Email = "morielbien@gmail.com",
                    Password = "testing4",
                    Status = 1
                }
                );
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Pancakes",
                    Preparation = "Mix ingredients and cook on a skillet until golden brown.",
                    CuisineType = "American",
                    MealType = "Breakfast",
                    CookingDifficulty = "Beginner",
                    PreparationTime = 20,
                    ServingCount = 4,
                    CreatorId = 1
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Tomato Soup",
                    Preparation = "Blend tomatoes and simmer with spices.",
                    CuisineType = "Italian",
                    MealType = "Lunch",
                    CookingDifficulty = "Intermediate",
                    PreparationTime = 30,
                    ServingCount = 3,
                    CreatorId = 2
                }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Flour", Category = "Baking" },
                new Ingredient { Id = 2, Name = "Sugar", Category = "Baking" },
                new Ingredient { Id = 3, Name = "Eggs", Category = "Dairy" },
                new Ingredient { Id = 4, Name = "Butter", Category = "Dairy" },
                new Ingredient { Id = 5, Name = "Tomatoes", Category = "Vegetables" }
                );
            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, Quantity = 2, Unit = "cups" },
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, Quantity = 0.5, Unit = "cups" },
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, Quantity = 2, Unit = "pieces" },
                new RecipeIngredient { Id = 4, RecipeId = 2, IngredientId = 5, Quantity = 4, Unit = "pieces" }
                );
            modelBuilder.Entity<Pantry>().HasData(
                new Pantry { Id = 1, AccountId = 1, IngredientId = 1 },
                new Pantry { Id = 2, AccountId = 1, IngredientId = 2 },
                new Pantry { Id = 3, AccountId = 2, IngredientId = 3 },
                new Pantry { Id = 4, AccountId = 2, IngredientId = 5 }
                );
        }
    }
}
