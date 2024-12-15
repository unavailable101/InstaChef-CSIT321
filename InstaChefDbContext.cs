using InstaChef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstaChef
{
    public class InstaChefDbContext : DbContext
    {
        //register tables
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<ChefRecipes> ChefRecipes { get; set;}

        //temporary data siguro, built-in bha
        // ayy basta oi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
            .Property(ri => ri.Id)
            .ValueGeneratedOnAdd(); 
            
            modelBuilder.Entity<Recipe>()
            .Property(ri => ri.Id)
            .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<RecipeIngredient>()
            .Property(ri => ri.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ChefRecipes>()
            .Property(ri => ri.Id)
            .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
 
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
            modelBuilder.Entity<ChefRecipes>().HasData(
                new ChefRecipes
                {
                    Id = 1,
                    Name = "Pancakes",
                    Description = "Classic fluffy pancakes perfect for breakfast.",
                    Preparation = "Mix ingredients and cook on a skillet until golden brown.",
                    CuisineType = "American",
                    MealType = "Breakfast",
                    CookingDifficulty = "Beginner",
                    PreparationTime = 20,
                    ServingCount = 4,
                    Category = 1 // Trending
                },
                new ChefRecipes
                {
                    Id = 2,
                    Name = "Spaghetti Carbonara",
                    Description = "Creamy Italian pasta with pancetta and Parmesan.",
                    Preparation = "Cook pasta and toss with eggs, cheese, and pancetta.",
                    CuisineType = "Italian",
                    MealType = "Dinner",
                    CookingDifficulty = "Intermediate",
                    PreparationTime = 30,
                    ServingCount = 2,
                    Category = 2 // Popular
                }
                // Add more recipes here, based on the data from the CSV file
            );
            //modelBuilder.Entity<Ingredient>().HasData(
            //    new Ingredient { Id = 1, Name = "Flour", Category = "Baking" },
            //    new Ingredient { Id = 2, Name = "Sugar", Category = "Baking" },
            //    new Ingredient { Id = 3, Name = "Eggs", Category = "Dairy" },
            //    new Ingredient { Id = 4, Name = "Butter", Category = "Dairy" },
            //    new Ingredient { Id = 5, Name = "Tomatoes", Category = "Vegetables" }
            //    );
            // Baking Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Flour", Category = "Baking" },
                new Ingredient { Id = 2, Name = "Sugar", Category = "Baking" },
                new Ingredient { Id = 3, Name = "Yeast", Category = "Baking" },
                new Ingredient { Id = 4, Name = "Baking Powder", Category = "Baking" },
                new Ingredient { Id = 5, Name = "Baking Soda", Category = "Baking" },
                new Ingredient { Id = 6, Name = "Vanilla Extract", Category = "Baking" },
                new Ingredient { Id = 7, Name = "Cocoa Powder", Category = "Baking" },
                new Ingredient { Id = 8, Name = "Cornstarch", Category = "Baking" }
                );

            // Vegetables
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 9, Name = "Tomatoes", Category = "Vegetables" },
                new Ingredient { Id = 10, Name = "Carrots", Category = "Vegetables" },
                new Ingredient { Id = 11, Name = "Spinach", Category = "Vegetables" },
                new Ingredient { Id = 12, Name = "Potatoes", Category = "Vegetables" },
                new Ingredient { Id = 13, Name = "Onions", Category = "Vegetables" },
                new Ingredient { Id = 14, Name = "Garlic", Category = "Vegetables" },
                new Ingredient { Id = 15, Name = "Peppers", Category = "Vegetables" },
                new Ingredient { Id = 16, Name = "Cucumber", Category = "Vegetables" }
                );

            // Fruits
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 17, Name = "Apples", Category = "Fruits" },
                new Ingredient { Id = 18, Name = "Bananas", Category = "Fruits" },
                new Ingredient { Id = 19, Name = "Oranges", Category = "Fruits" },
                new Ingredient { Id = 20, Name = "Lemons", Category = "Fruits" },
                new Ingredient { Id = 21, Name = "Strawberries", Category = "Fruits" },
                new Ingredient { Id = 22, Name = "Blueberries", Category = "Fruits" },
                new Ingredient { Id = 23, Name = "Grapes", Category = "Fruits" },
                new Ingredient { Id = 24, Name = "Pineapple", Category = "Fruits" }
                );

            // Meat
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 25, Name = "Chicken", Category = "Meat" },
                new Ingredient { Id = 26, Name = "Beef", Category = "Meat" },
                new Ingredient { Id = 27, Name = "Pork", Category = "Meat" },
                new Ingredient { Id = 28, Name = "Lamb", Category = "Meat" },
                new Ingredient { Id = 29, Name = "Turkey", Category = "Meat" },
                new Ingredient { Id = 30, Name = "Duck", Category = "Meat" },
                new Ingredient { Id = 31, Name = "Bacon", Category = "Meat" },
                new Ingredient { Id = 32, Name = "Ham", Category = "Meat" }
                );

            // Seafood
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 33, Name = "Shrimp", Category = "Seafood" },
                new Ingredient { Id = 34, Name = "Crab", Category = "Seafood" },
                new Ingredient { Id = 35, Name = "Salmon", Category = "Seafood" },
                new Ingredient { Id = 36, Name = "Tuna", Category = "Seafood" },
                new Ingredient { Id = 37, Name = "Lobster", Category = "Seafood" },
                new Ingredient { Id = 38, Name = "Cod", Category = "Seafood" },
                new Ingredient { Id = 39, Name = "Mussels", Category = "Seafood" },
                new Ingredient { Id = 40, Name = "Clams", Category = "Seafood" }
                );

            // Dairy
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 41, Name = "Milk", Category = "Dairy" },
                new Ingredient { Id = 42, Name = "Cheese", Category = "Dairy" },
                new Ingredient { Id = 43, Name = "Yogurt", Category = "Dairy" },
                new Ingredient { Id = 44, Name = "Cream", Category = "Dairy" },
                new Ingredient { Id = 45, Name = "Butter", Category = "Dairy" },
                new Ingredient { Id = 46, Name = "Sour Cream", Category = "Dairy" },
                new Ingredient { Id = 47, Name = "Whipped Cream", Category = "Dairy" },
                new Ingredient { Id = 48, Name = "Cottage Cheese", Category = "Dairy" }
                );

            // Spices and Herbs
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 49, Name = "Salt", Category = "Spices" },
                new Ingredient { Id = 50, Name = "Pepper", Category = "Spices" },
                new Ingredient { Id = 51, Name = "Cinnamon", Category = "Spices" },
                new Ingredient { Id = 52, Name = "Paprika", Category = "Spices" },
                new Ingredient { Id = 53, Name = "Cumin", Category = "Spices" },
                new Ingredient { Id = 54, Name = "Basil", Category = "Herbs" },
                new Ingredient { Id = 55, Name = "Oregano", Category = "Herbs" },
                new Ingredient { Id = 56, Name = "Parsley", Category = "Herbs" },
                new Ingredient { Id = 57, Name = "Rosemary", Category = "Herbs" }
            );

            // Grains and Starches
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 58, Name = "Rice", Category = "Grains" },
                new Ingredient { Id = 59, Name = "Pasta", Category = "Grains" },
                new Ingredient { Id = 60, Name = "Quinoa", Category = "Grains" },
                new Ingredient { Id = 61, Name = "Oats", Category = "Grains" },
                new Ingredient { Id = 62, Name = "Bread", Category = "Grains" },
                new Ingredient { Id = 63, Name = "Tortillas", Category = "Grains" },
                new Ingredient { Id = 64, Name = "Noodles", Category = "Grains" }
                );
            //Condiments
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 65, Name = "Soy Sauce", Category = "Condiments" },
                new Ingredient { Id = 66, Name = "Hot Sauce", Category = "Condiments" },
                new Ingredient { Id = 67, Name = "BBQ Sauce", Category = "Condiments" },
                new Ingredient { Id = 68, Name = "Tamari", Category = "Condiments" },
                new Ingredient { Id = 69, Name = "Dijon Mustard", Category = "Condiments" },
                new Ingredient { Id = 70, Name = "Ketchup", Category = "Condiments" },
                new Ingredient { Id = 71, Name = "Sriracha", Category = "Condiments" },
                new Ingredient { Id = 72, Name = "Oyster Sauce", Category = "Condiments" },
                new Ingredient { Id = 73, Name = "Ginger-Garlic Paste", Category = "Condiments" },
                new Ingredient { Id = 74, Name = "Teriyaki Sauce", Category = "Condiments" },
                new Ingredient { Id = 75, Name = "Prepared Horseradish", Category = "Condiments" },
                new Ingredient { Id = 76, Name = "Dark Soy Sauce", Category = "Condiments" },
                new Ingredient { Id = 77, Name = "Chili Paste", Category = "Condiments" },
                new Ingredient { Id = 78, Name = "Tamarind Paste", Category = "Condiments" },
                new Ingredient { Id = 79, Name = "Mustard", Category = "Condiments" },
                new Ingredient { Id = 80, Name = "Harissa", Category = "Condiments" },
                new Ingredient { Id = 81, Name = "Worcestershire", Category = "Condiments" },
                new Ingredient { Id = 82, Name = "Fish Sauce", Category = "Condiments" },
                new Ingredient { Id = 83, Name = "Wholegrain Mustard", Category = "Condiments" },
                new Ingredient { Id = 84, Name = "Chili Sauce", Category = "Condiments" },
                new Ingredient { Id = 85, Name = "Brown Mustard", Category = "Condiments" },
                new Ingredient { Id = 86, Name = "Wing Sauce", Category = "Condiments" },
                new Ingredient { Id = 87, Name = "Ginger Paste", Category = "Condiments" },
                new Ingredient { Id = 88, Name = "Coconut Aminos", Category = "Condiments" },
                new Ingredient { Id = 89, Name = "Chili-Garlic Sauce", Category = "Condiments" },
                new Ingredient { Id = 90, Name = "Pomegranate Molasses", Category = "Condiments" },
                new Ingredient { Id = 91, Name = "Chutney", Category = "Condiments" },
                new Ingredient { Id = 92, Name = "Green Chutney", Category = "Condiments" },
                new Ingredient { Id = 93, Name = "Liquid Aminos", Category = "Condiments" },
                new Ingredient { Id = 94, Name = "Gochujang", Category = "Condiments" },
                new Ingredient { Id = 95, Name = "Honey Mustard", Category = "Condiments" },
                new Ingredient { Id = 96, Name = "English Mustard", Category = "Condiments" },
                new Ingredient { Id = 97, Name = "Kecap Manis", Category = "Condiments" },
                new Ingredient { Id = 98, Name = "Thai Sweet Chili Sauce", Category = "Condiments" },
                new Ingredient { Id = 99, Name = "Sweet and Sour Sauce", Category = "Condiments" },
                new Ingredient { Id = 100, Name = "Hot Pepper Jelly", Category = "Condiments" },
                new Ingredient { Id = 101, Name = "Tartar Sauce", Category = "Condiments" },
                new Ingredient { Id = 102, Name = "Mexican Hot Sauce", Category = "Condiments" },
                new Ingredient { Id = 103, Name = "Green Chili Sauce", Category = "Condiments" },
                new Ingredient { Id = 104, Name = "Thai Chili Paste", Category = "Condiments" },
                new Ingredient { Id = 105, Name = "Wasabi", Category = "Condiments" },
                new Ingredient { Id = 106, Name = "Sambal Oelek", Category = "Condiments" },
                new Ingredient { Id = 107, Name = "Mango Chutney", Category = "Condiments" },
                new Ingredient { Id = 108, Name = "Preserved Lemon", Category = "Condiments" },
                new Ingredient { Id = 109, Name = "Shrimp Paste", Category = "Condiments" },
                new Ingredient { Id = 110, Name = "Picante Sauce", Category = "Condiments" },
                new Ingredient { Id = 111, Name = "Chili-Garlic Paste", Category = "Condiments" },
                new Ingredient { Id = 112, Name = "Bonito Flakes", Category = "Condiments" },
                new Ingredient { Id = 113, Name = "Red Pepper Jelly", Category = "Condiments" },
                new Ingredient { Id = 114, Name = "Crispy Onions", Category = "Condiments" },
                new Ingredient { Id = 115, Name = "Ponzu", Category = "Condiments" },
                new Ingredient { Id = 116, Name = "Peri Peri", Category = "Condiments" },
                new Ingredient { Id = 117, Name = "Giardiniera", Category = "Condiments" },
                new Ingredient { Id = 118, Name = "Duck Sauce", Category = "Condiments" },
                new Ingredient { Id = 119, Name = "Doubanjiang", Category = "Condiments" },
                new Ingredient { Id = 120, Name = "Doenjang", Category = "Condiments" },
                new Ingredient { Id = 121, Name = "Maggi Sauce", Category = "Condiments" },
                new Ingredient { Id = 122, Name = "Lime Pickle", Category = "Condiments" },
                new Ingredient { Id = 123, Name = "Chamoy", Category = "Condiments" },
                new Ingredient { Id = 124, Name = "Green Chili Paste", Category = "Condiments" },
                new Ingredient { Id = 125, Name = "Red Pepper Relish", Category = "Condiments" },
                new Ingredient { Id = 126, Name = "Horseradish Mustard", Category = "Condiments" },
                new Ingredient { Id = 127, Name = "Ginger Chili Paste", Category = "Condiments" },
                new Ingredient { Id = 128, Name = "Onion Marmalade", Category = "Condiments" },
                new Ingredient { Id = 129, Name = "Chermoula", Category = "Condiments" },
                new Ingredient { Id = 130, Name = "Tonkatsu Sauce", Category = "Condiments" },
                new Ingredient { Id = 131, Name = "Black Soy Sauce", Category = "Condiments" },
                new Ingredient { Id = 132, Name = "Korean BBQ Sauce", Category = "Condiments" },
                new Ingredient { Id = 133, Name = "Chinese Mustard", Category = "Condiments" },
                new Ingredient { Id = 134, Name = "Mushroom Soy Sauce", Category = "Condiments" },
                new Ingredient { Id = 135, Name = "German Mustard", Category = "Condiments" },
                new Ingredient { Id = 136, Name = "Banana Ketchup", Category = "Condiments" },
                new Ingredient { Id = 137, Name = "Hot Pepper Relish", Category = "Condiments" },
                new Ingredient { Id = 138, Name = "Eel Sauce", Category = "Condiments" },
                new Ingredient { Id = 139, Name = "Aji Amarillo", Category = "Condiments" },
                new Ingredient { Id = 140, Name = "Mint Jelly", Category = "Condiments" },
                new Ingredient { Id = 141, Name = "Mustard Paste", Category = "Condiments" },
                new Ingredient { Id = 142, Name = "Tamarind Chutney", Category = "Condiments" },
                new Ingredient { Id = 143, Name = "Yuzu Juice", Category = "Condiments" },
                new Ingredient { Id = 144, Name = "HP Sauce", Category = "Condiments" },
                new Ingredient { Id = 145, Name = "Chili Crisp", Category = "Condiments" },
                new Ingredient { Id = 146, Name = "Karashi", Category = "Condiments" },
                new Ingredient { Id = 147, Name = "Taucheo", Category = "Condiments" },
                new Ingredient { Id = 148, Name = "Yuzu Kosho", Category = "Condiments" },
                new Ingredient { Id = 149, Name = "Remoulade", Category = "Condiments" },
                new Ingredient { Id = 150, Name = "Guk Ganjang", Category = "Condiments" }
                );
            //Vegetables
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 151, Name = "Onion", Category = "Vegetables" },
                new Ingredient { Id = 152, Name = "Bell Pepper", Category = "Vegetables" },
                new Ingredient { Id = 153, Name = "Tomato", Category = "Vegetables" },
                new Ingredient { Id = 154, Name = "Avocado", Category = "Vegetables" },
                new Ingredient { Id = 155, Name = "Carrot", Category = "Vegetables" },
                new Ingredient { Id = 156, Name = "Red Onion", Category = "Vegetables" },
                new Ingredient { Id = 157, Name = "Shallot", Category = "Vegetables" },
                new Ingredient { Id = 158, Name = "Baby Greens", Category = "Vegetables" },
                new Ingredient { Id = 159, Name = "Asparagus", Category = "Vegetables" },
                new Ingredient { Id = 160, Name = "Kale", Category = "Vegetables" },
                new Ingredient { Id = 161, Name = "Corn", Category = "Vegetables" },
                new Ingredient { Id = 162, Name = "Leek", Category = "Vegetables" },
                new Ingredient { Id = 163, Name = "Lettuce", Category = "Vegetables" },
                new Ingredient { Id = 164, Name = "Romaine", Category = "Vegetables" },
                new Ingredient { Id = 165, Name = "Radish", Category = "Vegetables" },
                new Ingredient { Id = 166, Name = "Summer Squash", Category = "Vegetables" },
                new Ingredient { Id = 167, Name = "Parsnip", Category = "Vegetables" },
                new Ingredient { Id = 168, Name = "Iceberg", Category = "Vegetables" },
                new Ingredient { Id = 169, Name = "Mashed Potatoes", Category = "Vegetables" },
                new Ingredient { Id = 170, Name = "Chard", Category = "Vegetables" },
                new Ingredient { Id = 171, Name = "Scallion", Category = "Vegetables" },
                new Ingredient { Id = 172, Name = "Celery", Category = "Vegetables" },
                new Ingredient { Id = 173, Name = "Cherry Tomato", Category = "Vegetables" },
                new Ingredient { Id = 174, Name = "Sweet Potato", Category = "Vegetables" },
                new Ingredient { Id = 175, Name = "Pumpkin", Category = "Vegetables" },
                new Ingredient { Id = 176, Name = "Cabbage", Category = "Vegetables" },
                new Ingredient { Id = 177, Name = "Eggplant", Category = "Vegetables" },
                new Ingredient { Id = 178, Name = "Beetroot", Category = "Vegetables" },
                new Ingredient { Id = 179, Name = "Sun Dried Tomato", Category = "Vegetables" },
                new Ingredient { Id = 180, Name = "Red Cabbage", Category = "Vegetables" },
                new Ingredient { Id = 181, Name = "New Potato", Category = "Vegetables" },
                new Ingredient { Id = 182, Name = "Baby Carrot", Category = "Vegetables" },
                new Ingredient { Id = 183, Name = "Sweet Pepper", Category = "Vegetables" },
                new Ingredient { Id = 184, Name = "Watercress", Category = "Vegetables" },
                new Ingredient { Id = 185, Name = "Hash Browns", Category = "Vegetables" },
                new Ingredient { Id = 186, Name = "Butter Lettuce", Category = "Vegetables" },
                new Ingredient { Id = 187, Name = "Spaghetti Squash", Category = "Vegetables" },
                new Ingredient { Id = 188, Name = "Bok Choy", Category = "Vegetables" },
                new Ingredient { Id = 189, Name = "Water Chestnut", Category = "Vegetables" },
                new Ingredient { Id = 190, Name = "Leaf Lettuce", Category = "Vegetables" },
                new Ingredient { Id = 191, Name = "Okra", Category = "Vegetables" },
                new Ingredient { Id = 192, Name = "Potato", Category = "Vegetables" },
                new Ingredient { Id = 193, Name = "Zucchini", Category = "Vegetables" },
                new Ingredient { Id = 194, Name = "Broccoli", Category = "Vegetables" },
                new Ingredient { Id = 195, Name = "Cauliflower", Category = "Vegetables" },
                new Ingredient { Id = 196, Name = "Arugula", Category = "Vegetables" },
                new Ingredient { Id = 197, Name = "Butternut Squash", Category = "Vegetables" },
                new Ingredient { Id = 198, Name = "Brussels Sprout", Category = "Vegetables" },
                new Ingredient { Id = 199, Name = "Fennel", Category = "Vegetables" },
                new Ingredient { Id = 200, Name = "Artichoke", Category = "Vegetables" },
                new Ingredient { Id = 201, Name = "Mixed Greens", Category = "Vegetables" },
                new Ingredient { Id = 202, Name = "Mixed Vegetable", Category = "Vegetables" },
                new Ingredient { Id = 203, Name = "Green Tomato", Category = "Vegetables" },
                new Ingredient { Id = 204, Name = "Horseradish", Category = "Vegetables" },
                new Ingredient { Id = 205, Name = "Pimiento", Category = "Vegetables" },
                new Ingredient { Id = 206, Name = "Napa Cabbage", Category = "Vegetables" },
                new Ingredient { Id = 207, Name = "Celeriac", Category = "Vegetables" },
                new Ingredient { Id = 208, Name = "Corn Cob", Category = "Vegetables" },
                new Ingredient { Id = 209, Name = "Radicchio", Category = "Vegetables" },
                new Ingredient { Id = 210, Name = "Cavolo Nero", Category = "Vegetables" },
                new Ingredient { Id = 211, Name = "Coleslaw", Category = "Vegetables" },
                new Ingredient { Id = 212, Name = "Turnip", Category = "Vegetables" },
                new Ingredient { Id = 213, Name = "Acorn Squash", Category = "Vegetables" },
                new Ingredient { Id = 214, Name = "Pearl Onion", Category = "Vegetables" },
                new Ingredient { Id = 215, Name = "Tenderstem Broccoli", Category = "Vegetables" },
                new Ingredient { Id = 216, Name = "Jicama", Category = "Vegetables" },
                new Ingredient { Id = 217, Name = "French-Fried Onions", Category = "Vegetables" },
                new Ingredient { Id = 218, Name = "Rutabaga", Category = "Vegetables" },
                new Ingredient { Id = 219, Name = "Belgian Endive", Category = "Vegetables" },
                new Ingredient { Id = 220, Name = "Microgreens", Category = "Vegetables" },
                new Ingredient { Id = 221, Name = "Delicata Squash", Category = "Vegetables" },
                new Ingredient { Id = 222, Name = "Frisee", Category = "Vegetables" },
                new Ingredient { Id = 223, Name = "French Fries", Category = "Vegetables" },
                new Ingredient { Id = 224, Name = "Lamb's Lettuce", Category = "Vegetables" },
                new Ingredient { Id = 225, Name = "Garlic Scapes", Category = "Vegetables" },
                new Ingredient { Id = 226, Name = "Plantain", Category = "Vegetables" },
                new Ingredient { Id = 227, Name = "Corn Husk", Category = "Vegetables" },
                new Ingredient { Id = 228, Name = "Baby Corn", Category = "Vegetables" },
                new Ingredient { Id = 229, Name = "Endive", Category = "Vegetables" },
                new Ingredient { Id = 230, Name = "Kohlrabi", Category = "Vegetables" },
                new Ingredient { Id = 231, Name = "Yam", Category = "Vegetables" },
                new Ingredient { Id = 232, Name = "Baby Bok Choy", Category = "Vegetables" },
                new Ingredient { Id = 233, Name = "Collard Greens", Category = "Vegetables" },
                new Ingredient { Id = 234, Name = "Daikon", Category = "Vegetables" },
                new Ingredient { Id = 235, Name = "Potato Flakes", Category = "Vegetables" },
                new Ingredient { Id = 236, Name = "Broccoli Rabe", Category = "Vegetables" }
            );
            //Fruits 
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 237, Name = "Lemon", Category = "Fruits" },
                new Ingredient { Id = 238, Name = "Raisins", Category = "Fruits" },
                new Ingredient { Id = 239, Name = "Date", Category = "Fruits" },
                new Ingredient { Id = 240, Name = "Apple", Category = "Fruits" },
                new Ingredient { Id = 241, Name = "Orange", Category = "Fruits" },
                new Ingredient { Id = 242, Name = "Peach", Category = "Fruits" },
                new Ingredient { Id = 243, Name = "Pear", Category = "Fruits" },
                new Ingredient { Id = 244, Name = "Grape", Category = "Fruits" },
                new Ingredient { Id = 245, Name = "Rhubarb", Category = "Fruits" },
                new Ingredient { Id = 246, Name = "Plum", Category = "Fruits" },
                new Ingredient { Id = 247, Name = "Prunes", Category = "Fruits" },
                new Ingredient { Id = 248, Name = "Fio", Category = "Fruits" },
                new Ingredient { Id = 249, Name = "Banana", Category = "Fruits" },
                new Ingredient { Id = 250, Name = "Coconut", Category = "Fruits" },
                new Ingredient { Id = 251, Name = "Watermelon", Category = "Fruits" },
                new Ingredient { Id = 252, Name = "Kiwi", Category = "Fruits" },
                new Ingredient { Id = 253, Name = "Mandarin", Category = "Fruits" },
                new Ingredient { Id = 254, Name = "Grapefruit", Category = "Fruits" },
                new Ingredient { Id = 255, Name = "Currant", Category = "Fruits" },
                new Ingredient { Id = 256, Name = "Papaya", Category = "Fruits" },
                new Ingredient { Id = 257, Name = "Dried Fig", Category = "Fruits" },
                new Ingredient { Id = 258, Name = "Sultanas", Category = "Fruits" },
                new Ingredient { Id = 259, Name = "Tamarind", Category = "Fruits" },
                new Ingredient { Id = 260, Name = "Chestnut", Category = "Fruits" },
                new Ingredient { Id = 261, Name = "Dried Fruit", Category = "Fruits" },
                new Ingredient { Id = 262, Name = "Persimmon", Category = "Fruits" },
                new Ingredient { Id = 263, Name = "Tangerine", Category = "Fruits" },
                new Ingredient { Id = 264, Name = "Quince", Category = "Fruits" },
                new Ingredient { Id = 265, Name = "Lime", Category = "Fruits" },
                new Ingredient { Id = 266, Name = "Mango", Category = "Fruits" },
                new Ingredient { Id = 267, Name = "Craisins", Category = "Fruits" },
                new Ingredient { Id = 268, Name = "Pomegranate", Category = "Fruits" },
                new Ingredient { Id = 269, Name = "Dried Apricot", Category = "Fruits" },
                new Ingredient { Id = 270, Name = "Apricot", Category = "Fruits" },
                new Ingredient { Id = 271, Name = "Cantaloupe", Category = "Fruits" },
                new Ingredient { Id = 272, Name = "Passion Fruit", Category = "Fruits" },
                new Ingredient { Id = 273, Name = "Nectarine", Category = "Fruits" },
                new Ingredient { Id = 274, Name = "Meyer Lemon", Category = "Fruits" },
                new Ingredient { Id = 275, Name = "Clementine", Category = "Fruits" },
                new Ingredient { Id = 276, Name = "Dried Mango", Category = "Fruits" },
                new Ingredient { Id = 277, Name = "Banana Chips", Category = "Fruits" },
                new Ingredient { Id = 278, Name = "Mixed Fruit", Category = "Fruits" },
                new Ingredient { Id = 279, Name = "Dragon Fruit", Category = "Fruits" },
                new Ingredient { Id = 280, Name = "Young Coconut", Category = "Fruits" },
                new Ingredient { Id = 281, Name = "Star Fruit", Category = "Fruits" },
                new Ingredient { Id = 282, Name = "Pomelo", Category = "Fruits" },
                new Ingredient { Id = 283, Name = "Prickly Pear", Category = "Fruits" },
                new Ingredient { Id = 284, Name = "Dried Peach", Category = "Fruits" },
                new Ingredient { Id = 285, Name = "Kokum", Category = "Fruits" },
                new Ingredient { Id = 286, Name = "Dried Lemon", Category = "Fruits" },
                new Ingredient { Id = 287, Name = "Custard-Apple", Category = "Fruits" },
                new Ingredient { Id = 288, Name = "Freeze-Dried Apple", Category = "Fruits" },
                new Ingredient { Id = 289, Name = "Dried Tamarind", Category = "Fruits" },
                new Ingredient { Id = 290, Name = "Physalis", Category = "Fruits" },
                new Ingredient { Id = 291, Name = "Bitter Orange", Category = "Fruits" },
                new Ingredient { Id = 292, Name = "Dried Persimmons", Category = "Fruits" },
                new Ingredient { Id = 293, Name = "Dried Orange Slice", Category = "Fruits" },
                new Ingredient { Id = 294, Name = "Guava", Category = "Fruits" },
                new Ingredient { Id = 295, Name = "Jackfruit", Category = "Fruits" },
                new Ingredient { Id = 296, Name = "Lychee", Category = "Fruits" },
                new Ingredient { Id = 297, Name = "Green Mango", Category = "Fruits" },
                new Ingredient { Id = 298, Name = "Dried Pears", Category = "Fruits" },
                new Ingredient { Id = 299, Name = "Calamansi", Category = "Fruits" },
                new Ingredient { Id = 300, Name = "Yuzu", Category = "Fruits" },
                new Ingredient { Id = 301, Name = "Mixed Peel", Category = "Fruits" },
                new Ingredient { Id = 302, Name = "Tangelo", Category = "Fruits" },
                new Ingredient { Id = 303, Name = "Young Jackfruit", Category = "Fruits" },
                new Ingredient { Id = 304, Name = "Sweet Lime", Category = "Fruits" },
                new Ingredient { Id = 305, Name = "Jujube", Category = "Fruits" },
                new Ingredient { Id = 306, Name = "Tamarillo", Category = "Fruits" },
                new Ingredient { Id = 307, Name = "Ice-Apple", Category = "Fruits" },
                new Ingredient { Id = 308, Name = "Chikoo", Category = "Fruits" },
                new Ingredient { Id = 309, Name = "Crabapple", Category = "Fruits" },
                new Ingredient { Id = 310, Name = "Rose Apple", Category = "Fruits" },
                new Ingredient { Id = 311, Name = "Honeydew Melon", Category = "Fruits" },
                new Ingredient { Id = 312, Name = "Melon", Category = "Fruits" },
                new Ingredient { Id = 313, Name = "Dried Apple", Category = "Fruits" },
                new Ingredient { Id = 314, Name = "Kumquat", Category = "Fruits" },
                new Ingredient { Id = 315, Name = "Asian Pear", Category = "Fruits" },
                new Ingredient { Id = 316, Name = "Dried Pineapple", Category = "Fruits" },
                new Ingredient { Id = 317, Name = "Kaffir Lime", Category = "Fruits" },
                new Ingredient { Id = 318, Name = "Green Papaya", Category = "Fruits" },
                new Ingredient { Id = 319, Name = "Chestnut Puree", Category = "Fruits" },
                new Ingredient { Id = 320, Name = "Apple Chips", Category = "Fruits" },
                new Ingredient { Id = 321, Name = "Granadilla", Category = "Fruits" },
                new Ingredient { Id = 322, Name = "Dried Lime", Category = "Fruits" },
                new Ingredient { Id = 323, Name = "Honey Date", Category = "Fruits" },
                new Ingredient { Id = 324, Name = "Durian", Category = "Fruits" },
                new Ingredient { Id = 325, Name = "Dried Watermelon", Category = "Fruits" }
                );

            //Dairy
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 326, Name = "Buttermilk", Category = "Dairy" },
                new Ingredient { Id = 327, Name = "Ghee", Category = "Dairy" },
                new Ingredient { Id = 328, Name = "Custard", Category = "Dairy" },
                new Ingredient { Id = 329, Name = "Sherbet", Category = "Dairy" },
                new Ingredient { Id = 330, Name = "Fried Eggs", Category = "Dairy" },
                new Ingredient { Id = 331, Name = "Quail Egg", Category = "Dairy" },
                new Ingredient { Id = 332, Name = "Poached Eggs", Category = "Dairy" },
                new Ingredient { Id = 333, Name = "Sour Milk", Category = "Dairy" },
                new Ingredient { Id = 334, Name = "Ganache", Category = "Dairy" },
                new Ingredient { Id = 335, Name = "Salted Egg", Category = "Dairy" },
                new Ingredient { Id = 336, Name = "Margarine", Category = "Dairy" },
                new Ingredient { Id = 337, Name = "Milk Powder", Category = "Dairy" },
                new Ingredient { Id = 338, Name = "Lemon Curd", Category = "Dairy" },
                new Ingredient { Id = 339, Name = "Liquid Egg Substitute", Category = "Dairy" },
                new Ingredient { Id = 340, Name = "Kefir", Category = "Dairy" },
                new Ingredient { Id = 341, Name = "Hung Curd", Category = "Dairy" },
                new Ingredient { Id = 342, Name = "Buttermilk Powder", Category = "Dairy" },
                new Ingredient { Id = 343, Name = "Khoya", Category = "Dairy" },
                new Ingredient { Id = 344, Name = "Clotted Cream", Category = "Dairy" },
                new Ingredient { Id = 345, Name = "Goat Milk", Category = "Dairy" },
                new Ingredient { Id = 346, Name = "Ice-Cream Sandwich", Category = "Dairy" },
                new Ingredient { Id = 347, Name = "Egg White Powder", Category = "Dairy" },
                new Ingredient { Id = 348, Name = "Raw Milk", Category = "Dairy" },
                new Ingredient { Id = 349, Name = "Cajeta", Category = "Dairy" },
                new Ingredient { Id = 350, Name = "Yogurt Starter", Category = "Dairy" },
                new Ingredient { Id = 351, Name = "Lime Curd", Category = "Dairy" },
                new Ingredient { Id = 352, Name = "Milkfat", Category = "Dairy" },
                new Ingredient { Id = 353, Name = "Strawberry Frosting", Category = "Dairy" },
                new Ingredient { Id = 354, Name = "Honey Butter", Category = "Dairy" },
                new Ingredient { Id = 355, Name = "Strawberry Cream Cheese", Category = "Dairy" },
                new Ingredient { Id = 356, Name = "Cookies n' Cream Ice Cream", Category = "Dairy" },
                new Ingredient { Id = 357, Name = "Century Egg", Category = "Dairy" },
                new Ingredient { Id = 358, Name = "Orange Curd", Category = "Dairy" },
                new Ingredient { Id = 359, Name = "Dahi", Category = "Dairy" },
                new Ingredient { Id = 360, Name = "Chantilly", Category = "Dairy" },
                new Ingredient { Id = 361, Name = "Ayran", Category = "Dairy" },
                new Ingredient { Id = 362, Name = "Cuajada", Category = "Dairy" },
                new Ingredient { Id = 363, Name = "Egg Powder", Category = "Dairy" },
                new Ingredient { Id = 364, Name = "Peppermint Mocha Creamer", Category = "Dairy" },
                new Ingredient { Id = 365, Name = "Key Lime Curd", Category = "Dairy" },
                new Ingredient { Id = 366, Name = "Chocolate Milk Powder", Category = "Dairy" },
                new Ingredient { Id = 367, Name = "Buffalo Milk", Category = "Dairy" },
                new Ingredient { Id = 368, Name = "Sheep Milk", Category = "Dairy" },
                new Ingredient { Id = 369, Name = "Goat Kefir", Category = "Dairy" },
                new Ingredient { Id = 370, Name = "Greek Yogurt", Category = "Dairy" },
                new Ingredient { Id = 371, Name = "Shortening", Category = "Dairy" },
                new Ingredient { Id = 372, Name = "Sweetened Condensed Milk", Category = "Dairy" },
                new Ingredient { Id = 373, Name = "Ice Cream", Category = "Dairy" },
                new Ingredient { Id = 374, Name = "Frosting", Category = "Dairy" },
                new Ingredient { Id = 375, Name = "Thickened Cream", Category = "Dairy" },
                new Ingredient { Id = 376, Name = "Dulce de Leche", Category = "Dairy" },
                new Ingredient { Id = 377, Name = "Chocolate Frosting", Category = "Dairy" },
                new Ingredient { Id = 378, Name = "Chocolate Milk", Category = "Dairy" },
                new Ingredient { Id = 379, Name = "Whey", Category = "Dairy" },
                new Ingredient { Id = 380, Name = "Frozen Yogurt", Category = "Dairy" },
                new Ingredient { Id = 381, Name = "Coffee Creamer", Category = "Dairy" },
                new Ingredient { Id = 382, Name = "Milk Cream", Category = "Dairy" },
                new Ingredient { Id = 383, Name = "Scrambled Eggs", Category = "Dairy" },
                new Ingredient { Id = 384, Name = "Duck Egg", Category = "Dairy" },
                new Ingredient { Id = 385, Name = "Sky", Category = "Dairy" },
                new Ingredient { Id = 386, Name = "Pumpkin Spice Coffee Creamer", Category = "Dairy" },
                new Ingredient { Id = 387, Name = "Honey Greek Yogurt", Category = "Dairy" },
                new Ingredient { Id = 388, Name = "Powdered Coffee Creamer", Category = "Dairy" },
                new Ingredient { Id = 389, Name = "Rainbow Sherbet", Category = "Dairy" },
                new Ingredient { Id = 390, Name = "Amul Butter", Category = "Dairy" },
                new Ingredient { Id = 391, Name = "Goat Yogurt", Category = "Dairy" },
                new Ingredient { Id = 392, Name = "Goat Butter", Category = "Dairy" },
                new Ingredient { Id = 393, Name = "Passionfruit Curd", Category = "Dairy" },
                new Ingredient { Id = 394, Name = "Sheep-Milk Yogurt", Category = "Dairy" },
                new Ingredient { Id = 395, Name = "Starter Culture", Category = "Dairy" },
                new Ingredient { Id = 396, Name = "Cinnamon Sugar Butter Spread", Category = "Dairy" },
                new Ingredient { Id = 397, Name = "Bulgarian Yogurt", Category = "Dairy" },
                new Ingredient { Id = 398, Name = "Key Lime Yogurt", Category = "Dairy" },
                new Ingredient { Id = 399, Name = "Tvorog", Category = "Dairy" },
                new Ingredient { Id = 400, Name = "Liquid Rennet", Category = "Dairy" },
                new Ingredient { Id = 401, Name = "Strawberry Milk", Category = "Dairy" },
                new Ingredient { Id = 402, Name = "Yogurt Drink", Category = "Dairy" },
                new Ingredient { Id = 403, Name = "Evaporated Goat Milk", Category = "Dairy" },
                new Ingredient { Id = 404, Name = "Vanilla Milk", Category = "Dairy" },
                new Ingredient { Id = 405, Name = "Kashk", Category = "Dairy" },
                new Ingredient { Id = 406, Name = "Ego", Category = "Dairy" },
                new Ingredient { Id = 407, Name = "Heavy Cream", Category = "Dairy" }
                );
            //Meat 
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 408, Name = "Deli Ham", Category = "Meat" },
                new Ingredient { Id = 409, Name = "Sweet Italian Sausage", Category = "Meat" },
                new Ingredient { Id = 410, Name = "Beef Roast", Category = "Meat" },
                new Ingredient { Id = 411, Name = "Beef Stew Meat", Category = "Meat" },
                new Ingredient { Id = 412, Name = "Pancetta", Category = "Meat" },
                new Ingredient { Id = 413, Name = "Ground Lamb", Category = "Meat" },
                new Ingredient { Id = 414, Name = "Breakfast Sausage", Category = "Meat" },
                new Ingredient { Id = 415, Name = "Salami", Category = "Meat" },
                new Ingredient { Id = 416, Name = "Beef Short Ribs", Category = "Meat" },
                new Ingredient { Id = 417, Name = "Hot Italian Sausage", Category = "Meat" },
                new Ingredient { Id = 418, Name = "Boneless Lamb", Category = "Meat" },
                new Ingredient { Id = 419, Name = "Pork Roast", Category = "Meat" },
                new Ingredient { Id = 420, Name = "Bone-in Ham", Category = "Meat" },
                new Ingredient { Id = 421, Name = "Lamb Chops", Category = "Meat" },
                new Ingredient { Id = 422, Name = "Veal Steak", Category = "Meat" },
                new Ingredient { Id = 423, Name = "Beef Sausage", Category = "Meat" },
                new Ingredient { Id = 424, Name = "Ham Steak", Category = "Meat" },
                new Ingredient { Id = 425, Name = "Bratwurst", Category = "Meat" },
                new Ingredient { Id = 426, Name = "Frozen Meatballs", Category = "Meat" },
                new Ingredient { Id = 427, Name = "Rabbit", Category = "Meat" },
                new Ingredient { Id = 428, Name = "Ground Beef", Category = "Meat" },
                new Ingredient { Id = 429, Name = "Pork Chops", Category = "Meat" },
                new Ingredient { Id = 430, Name = "Beef Steak", Category = "Meat" },
                new Ingredient { Id = 431, Name = "Prosciutto", Category = "Meat" },
                new Ingredient { Id = 432, Name = "Sausage", Category = "Meat" },
                new Ingredient { Id = 433, Name = "Chorizo", Category = "Meat" },
                new Ingredient { Id = 434, Name = "Pork Loin", Category = "Meat" },
                new Ingredient { Id = 435, Name = "Pork Nibs", Category = "Meat" },
                new Ingredient { Id = 436, Name = "Beef Sirloin", Category = "Meat" },
                new Ingredient { Id = 437, Name = "Brisket", Category = "Meat" },
                new Ingredient { Id = 438, Name = "Leg of Lamb", Category = "Meat" },
                new Ingredient { Id = 439, Name = "Pork Fillet", Category = "Meat" },
                new Ingredient { Id = 440, Name = "Ground Pork", Category = "Meat" },
                new Ingredient { Id = 441, Name = "Pepperoni", Category = "Meat" },
                new Ingredient { Id = 442, Name = "Pork Shoulder", Category = "Meat" },
                new Ingredient { Id = 443, Name = "Smoked Sausage", Category = "Meat" },
                new Ingredient { Id = 444, Name = "Hot Dog", Category = "Meat" },
                new Ingredient { Id = 445, Name = "Kielbasa", Category = "Meat" },
                new Ingredient { Id = 446, Name = "Pork Belly", Category = "Meat" },
                new Ingredient { Id = 447, Name = "Andouille", Category = "Meat" },
                new Ingredient { Id = 448, Name = "Pulled Pork", Category = "Meat" },
                new Ingredient { Id = 449, Name = "Pork Cutlets", Category = "Meat" },
                new Ingredient { Id = 450, Name = "Veal Cutlet", Category = "Meat" },
                new Ingredient { Id = 451, Name = "Mexican Chorizo", Category = "Meat" },
                new Ingredient { Id = 452, Name = "Country Style Ribs", Category = "Meat" },
                new Ingredient { Id = 453, Name = "Smoked Ham Hock", Category = "Meat" },
                new Ingredient { Id = 454, Name = "Raw Chorizo", Category = "Meat" },
                new Ingredient { Id = 455, Name = "Serrano Ham", Category = "Meat" },
                new Ingredient { Id = 456, Name = "Hard Salami", Category = "Meat" },
                new Ingredient { Id = 457, Name = "Veal Shank", Category = "Meat" },
                new Ingredient { Id = 458, Name = "Lap Cheong", Category = "Meat" },
                new Ingredient { Id = 459, Name = "Beef Shank", Category = "Meat" },
                new Ingredient { Id = 460, Name = "Country Ham", Category = "Meat" },
                new Ingredient { Id = 461, Name = "Gammon Joint", Category = "Meat" },
                new Ingredient { Id = 462, Name = "Bologna", Category = "Meat" },
                new Ingredient { Id = 463, Name = "Roast Beef", Category = "Meat" },
                new Ingredient { Id = 464, Name = "Pork Spare Ribs", Category = "Meat" },
                new Ingredient { Id = 465, Name = "Lamb Shoulder", Category = "Meat" },
                new Ingredient { Id = 466, Name = "Canadian Bacon", Category = "Meat" },
                new Ingredient { Id = 467, Name = "Lamb Shank", Category = "Meat" },
                new Ingredient { Id = 468, Name = "Venison", Category = "Meat" },
                new Ingredient { Id = 469, Name = "Mixed Ground Meat", Category = "Meat" },
                new Ingredient { Id = 470, Name = "Ham Hock", Category = "Meat" },
                new Ingredient { Id = 471, Name = "Lamb Loin", Category = "Meat" },
                new Ingredient { Id = 472, Name = "Pork Back Ribs", Category = "Meat" },
                new Ingredient { Id = 473, Name = "Black Forest Ham", Category = "Meat" },
                new Ingredient { Id = 474, Name = "Soup Bones", Category = "Meat" },
                new Ingredient { Id = 475, Name = "Beef Liver", Category = "Meat" },
                new Ingredient { Id = 476, Name = "Cocktail Sausage", Category = "Meat" },
                new Ingredient { Id = 477, Name = "Boneless Ham", Category = "Meat" },
                new Ingredient { Id = 478, Name = "Ground Venison", Category = "Meat" },
                new Ingredient { Id = 479, Name = "Blood Sausage", Category = "Meat" },
                new Ingredient { Id = 480, Name = "Fresh Sausage", Category = "Meat" },
                new Ingredient { Id = 481, Name = "Boneless Beef Short Ribs", Category = "Meat" },
                new Ingredient { Id = 482, Name = "Cooked Pork", Category = "Meat" },
                new Ingredient { Id = 483, Name = "Burger Patty", Category = "Meat" },
                new Ingredient { Id = 484, Name = "Sausage Patty", Category = "Meat" },
                new Ingredient { Id = 485, Name = "Beef Shoulder", Category = "Meat" },
                new Ingredient { Id = 486, Name = "Ground Pork Sausage", Category = "Meat" },
                new Ingredient { Id = 487, Name = "Ground Sausage", Category = "Meat" },
                new Ingredient { Id = 488, Name = "Bacon Bits", Category = "Meat" },
                new Ingredient { Id = 489, Name = "Beef Ribs", Category = "Meat" },
                new Ingredient { Id = 490, Name = "Pork Butt", Category = "Meat" },
                new Ingredient { Id = 491, Name = "Mutton", Category = "Meat" },
                new Ingredient { Id = 492, Name = "Oxtail", Category = "Meat" },
                new Ingredient { Id = 493, Name = "Lamb Leg", Category = "Meat" },
                new Ingredient { Id = 494, Name = "Pork Jowl", Category = "Meat" },
                new Ingredient { Id = 495, Name = "Beef Tenderloin", Category = "Meat" },
                new Ingredient { Id = 496, Name = "Wiener", Category = "Meat" }
            );


            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, Quantity = 2, Unit = "cups" },
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, Quantity = 0.5, Unit = "cups" },
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, Quantity = 2, Unit = "pieces" },
                new RecipeIngredient { Id = 4, RecipeId = 2, IngredientId = 5, Quantity = 4, Unit = "pieces" }
                );

           
        }
    }
}
