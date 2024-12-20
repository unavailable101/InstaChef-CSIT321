﻿using InstaChef.DTO;

namespace InstaChef.Services
{
    public interface IBrowseServices
    {
        public string GetTrendingRecipes();
        public string GetNewRecipes();
        public string GetPopularRecipes();
        public string GetSavedRecipes();
        public string GetLikedRecipes();
        public RecipeProfile? GetRecipeProfile(int id); //Recipe ang return type ani
        public List<RecipeProfile> GetAllRecipes();
    }
}
