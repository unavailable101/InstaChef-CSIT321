using InstaChef.Models;
using System.Diagnostics.Contracts;

namespace InstaChef
{
    public class TempDB
    {
        public static List<Account> tempAccountList = new List<Account>()
        {
            
        };

        //public List<Recipe> tempRecipes = new List<Recipe>()
        //{
        //    new Recipe
        //    {
        //        Id = 1,
        //        Name = "Adobo",
        //        Preparation = "secret",
        //        CuisineType = "Filipino",
        //        MealType = "Lunch",
        //        CookingDifficulty = "Intermediate",
        //        PreparationTime = 60,
        //        ServingCount = 8,
        //        RecipeIngredients = new List<RecipeIngredient>
        //        {
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Chicken cut ups", 
        //                    Quantity = "1 kilograms" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Canola Oil", 
        //                    Quantity = "2 tbsp" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Vinegar", 
        //                    Quantity = "2 tbsp" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Soy Sauce", 
        //                    Quantity = "1/4 cup" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Water", 
        //                    Quantity = "1 cup" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Black Peppercorns", 
        //                    Quantity = "1 tsp" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Bay Leaves", 
        //                    Quantity = "2 pcs" 
        //                }
        //            }
        //        },
        //        CreatorId = 3
        //    },
        //    new Recipe()
        //    {
        //        Id = 2,
        //        Name = "Buttered Shrimp",
        //        Preparation = "secret",
        //        CuisineType = "Filipino",
        //        MealType = "Lunch",
        //        CookingDifficulty = "Beginner",
        //        PreparationTime = 30,
        //        ServingCount = 5,
        //        RecipeIngredients = new List<RecipeIngredient>
        //        {
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Shrimp", 
        //                    Quantity = "500 grams" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Butter", 
        //                    Quantity = "300 grams" 
        //                }
        //            }
        //        },
        //        CreatorId = 1
        //    },
        //    new Recipe()
        //    {
        //        Id = 3,
        //        Name = "Spaghetti",
        //        Preparation = "secret",
        //        CuisineType = "Italian",
        //        MealType = "Lunch",
        //        CookingDifficulty = "Beginner",
        //        PreparationTime = 30,
        //        ServingCount = 5,
        //        RecipeIngredients = new List<RecipeIngredient>
        //        {
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Spaghetti", 
        //                    Quantity = "500 grams" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Ground beef", 
        //                    Quantity = "300 grams" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Tomato sauce", 
        //                    Quantity = "2 cups" 
        //                }
        //            }
        //        },
        //        CreatorId = 3
        //    },
        //    new Recipe()
        //    {
        //        Id = 4,
        //        Name = "Carbonara",
        //        Preparation = "secret",
        //        CuisineType = "Italian",
        //        MealType = "Lunch",
        //        CookingDifficulty = "Beginner",
        //        PreparationTime = 30,
        //        ServingCount = 5,
        //        RecipeIngredients = new List<RecipeIngredient>
        //        {
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Spaghetti", 
        //                    Quantity = "500 grams" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Eggs", 
        //                    Quantity = "2 pcs" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Cheese", 
        //                    Quantity = "2 cups" 
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient { 
        //                    Name = "Bacon", 
        //                    Quantity = "200 grams" 
        //                }
        //            }
        //        },
        //        CreatorId = 3
        //    },
        //    new Recipe()
        //    {
        //        Id = 5,
        //        Name = "Hamburger",
        //        Preparation = "secret",
        //        CuisineType = "American",
        //        MealType = "Lunch",
        //        CookingDifficulty = "Beginner",
        //        PreparationTime = 30,
        //        ServingCount = 2,
        //        RecipeIngredients = new List<RecipeIngredient>
        //        {
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient
        //                {
        //                    Name = "Egg", 
        //                    Quantity = "1 pc"
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient
        //                {
        //                    Name = "Ground Beef", 
        //                    Quantity = "1 pound"
        //                }
        //            },
        //            new RecipeIngredient
        //            {
        //                Ingredient = new Ingredient
        //                {
        //                    Name = "Ground Beef", 
        //                    Quantity = "1 pound"
        //                }
        //            }
        //        },
        //        CreatorId = 2
        //    }
        //};
    }
}
