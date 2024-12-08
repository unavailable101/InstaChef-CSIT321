namespace InstaChef.Services
{
    public interface IRecipeServices
    {
        public string GetMyRecipes();
        public string CreateRecipe();
        public bool EditRecipe();
        public string GenerateRecipe();
    }
}
