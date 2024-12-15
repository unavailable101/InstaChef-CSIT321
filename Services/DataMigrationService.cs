//using Microsoft.Data.Sqlite;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using InstaChef.DTO;

//namespace InstaChef.Services
//{
//    public class DataMigrationService : IDataMigrationService
//    {
//        private readonly SQLiteDbContext _sqliteContext;
//        private readonly InstaChefDbContext _instaChefDbContext;

//        public DataMigrationService(SQLiteDbContext sqliteContext, InstaChefDbContext instaChefDbContext)
//        {
//            _sqliteContext = sqliteContext;
//            _instaChefDbContext = instaChefDbContext;
//        }

//        public void MigrateData()
//        {
//            // Fetch all recipes from SQLite
//            var sqliteRecipes = _sqliteContext.Recipes.ToList();

//            foreach (var recipe in sqliteRecipes)
//            {
//                var newRecipe = new ChefRecipes
//                {
//                    Id = null, // Let SQL Server handle ID generation
//                    Name = recipe.Name,
//                    Ingredients = recipe.Ingredients,
//                    Preparation = recipe.Preparation,
//                    ImageName = recipe.ImageName,
//                    CuisineType = recipe.CuisineType,
//                    MealType = recipe.MealType,
//                    CookingDifficulty = recipe.CookingDifficulty,
//                    PreparationTime = recipe.PreparationTime,
//                    ServingCount = recipe.ServingCount
//                };

//                _instaChefDbContext.ChefRecipes.Add(newRecipe);
//            }

//            _instaChefDbContext.SaveChanges();
//            Console.WriteLine("Migration completed!");
//        }
//    }
//}
