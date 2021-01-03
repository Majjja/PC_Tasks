using Services;
using Services.Helpers;
using System;
using System.IO;
using System.Linq;

namespace RecipeBook_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathIngredients = Directory.GetCurrentDirectory() + @"\Ingredients.csv";
            var pathRecipes = Directory.GetCurrentDirectory() + @"\Recipes.csv";

            var ingredients = ProccessIngredients.GetIngredients(pathIngredients);
            var recipes = ProccessRecipes.GetRecipes(pathRecipes);

            Console.WriteLine("------------------- All Ingredients -------------------");

            //foreach (var ingredient in ingredients)
            //{
            //    Console.WriteLine($"{ingredient.Id} - {ingredient.Name} - {ingredient.QuantityAvailable} - {(int)ingredient.Unit}");
            //}

            Console.WriteLine("------------------- All Recipes -------------------");


            //foreach (var recipe in recipes)
            //{
            //    Console.WriteLine($"{recipe.Id} - {recipe.Name} - {recipe.PreparingTime}");
            //}

            Console.WriteLine("------------------- Users And Their Recipes -------------------");

            var usersRecipes = UserHelper.SetRecipesToUsers(recipes);

            //foreach (var user in usersRecipes)
            //{
            //    Console.WriteLine($"{user.Name} {user.Recipes.Count()}");
            //    foreach (var recipe in user.Recipes.ToList())
            //    {
            //        Console.WriteLine($"\t{recipe.Id} - {recipe.Name} - {recipe.PreparingTime}");
            //    }
            //}

            Console.WriteLine("------------------- User's Recipes -------------------");

            var recipeByUser = usersRecipes.SingleOrDefault(x => x.Id.Equals(new Guid("A3333333-B333-C333-D333-E33333333333")));
            
            Console.WriteLine(recipeByUser.Name);
            int count = 1;
            foreach (var recipe in recipeByUser.Recipes)
            {
                Console.WriteLine($"\t{count} : {recipe.Name} | Preparing Time : {recipe.PreparingTime}");
                count++;
            }
        }

    }
}
