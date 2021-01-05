using Domain.Enums;
using Domain.Models;
using Services;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RecipeBook_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientsCsv = "Ingredients.csv";
            var recipesCsv = "Recipes.csv";
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var pathIngredients = Path.Combine(currentDirectory, ingredientsCsv);
            var pathRecipes = Path.Combine(currentDirectory, recipesCsv);

            var ingredients = ProccessIngredients.GetIngredients(pathIngredients);
            var recipes = ProccessRecipes.GetRecipes(pathRecipes);

            Console.WriteLine("------------------- All Ingredients -------------------");
            foreach (var ingredient in ingredients)
                Console.WriteLine($"{ingredient.Id} - {ingredient.Name} - {ingredient.QuantityAvailable} - {(int)ingredient.Unit}");
            Console.WriteLine("");

            Console.WriteLine("------------------- All Recipes -------------------");
            foreach (var recipe in recipes)
                Console.WriteLine($"{recipe.Id} - {recipe.Name} - {recipe.PreparingTime}");
            Console.WriteLine("");

            Console.WriteLine("------------------- Users And Their Recipes -------------------");
            var usersRecipes = UserHelper.SetRecipesToUsers(recipes);
            foreach (var userr in usersRecipes)
            {
                Console.WriteLine($"{userr.Name} {userr.Recipes.Count()}");
                foreach (var recipe in userr.Recipes.ToList())
                {
                    Console.WriteLine($"\t{recipe.Id} - {recipe.Name} - {recipe.PreparingTime}");
                }
            }
            Console.WriteLine("");

            Console.WriteLine("------------------- User's Recipes -------------------");
            var recipeByUser = usersRecipes.SingleOrDefault(x => x.Id.Equals(3));
            Console.WriteLine(recipeByUser.Name);
            int count = 1;
            foreach (var recipe in recipeByUser.Recipes)
            {
                Console.WriteLine($"\t{count} : {recipe.Name} | Preparing Time : {recipe.PreparingTime}");
                count++;
            }
            Console.WriteLine("");

            // Creating new User with 2 Recipes ( with 3 Ingredients )
            var user = new User()
            {
                Id = 6,
                Name = "Lara",
                Recipes = new List<Recipe>()
                {
                    new Recipe()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Christmas Wreaths",
                        Instructions = "Quickly drop heaping tablespoonfuls of the mixture onto waxed paper, and form into a wreath shape with lightly greased fingers. Immediately decorate with red hot candies. Allow to cool to room temperature before removing from waxed paper, and storing in an airtight container.",
                        ServingQuantity = ServingQuantity.Four,
                        Notes = "112 calories; protein 0.7g; carbohydrates 16.7g; fat 5.2g; cholesterol 13.6mg; sodium 91.5mg",
                        SkillLevel = 0.111,
                        PreparingTime = 1,
                        Ingredients = new List<Ingredient>
                        {
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Butter",
                                QuantityAvailable = 3,
                                Unit = Unit.Two
                            },
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Marshmallows",
                                QuantityAvailable = 3,
                                Unit = Unit.One
                            },
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Cinnamon red hot candies",
                                QuantityAvailable = 2,
                                Unit = Unit.Three
                            }
                        }
                    },
                    new Recipe()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chocolate Chip Cookies",
                        Instructions = "In a mixing bowl, cream butter and sugars. Add pudding mix, eggs and vanilla. Combine flour and baking soda; add to creamed mixture and mix well. Fold in chocolate chips.",
                        ServingQuantity = ServingQuantity.Four,
                        Notes = "233 calories; protein 2.4g; carbohydrates 30.5g; fat 12.4g; cholesterol 35.8mg; sodium 175.3mg",
                        SkillLevel = 0.1,
                        PreparingTime = 2,
                        Ingredients = new List<Ingredient>
                        {
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Butter",
                                QuantityAvailable = 3,
                                Unit = Unit.Three
                            },
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sugar",
                                QuantityAvailable = 1,
                                Unit = Unit.Two
                            },
                            new Ingredient()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Chocolate Chips",
                                QuantityAvailable = 5,
                                Unit = Unit.One
                            }
                        }
                    }
                }
            };

            // Print User
            Console.WriteLine($"------------------- {user.Name}'s Recipes : -------------------");
            for (int i = 0; i < user.Recipes.Count; i++)
            {
                Console.WriteLine($"*** {i + 1} ***");
                Console.WriteLine($"Name : {user.Recipes[i].Name}");
                Console.WriteLine($"Instructions : {user.Recipes[i].Instructions}");
                Console.WriteLine($"Serving Quantity : {(int)user.Recipes[i].ServingQuantity}");
                Console.WriteLine($"Notes : {user.Recipes[i].Notes}");
                Console.WriteLine($"Skill Level : {user.Recipes[i].SkillLevel}");
                Console.WriteLine($"Preparing Time : {user.Recipes[i].PreparingTime}");
                Console.WriteLine($"Ingredients :");
                foreach (var ingredient in user.Recipes[i].Ingredients)
                {
                    Console.WriteLine($"\tName : {ingredient.Name}");
                    Console.WriteLine($"\tQuantity Available : {ingredient.QuantityAvailable}");
                    Console.WriteLine($"\tUnit : {(int)ingredient.Unit}");
                    Console.WriteLine("");
                }
            }
        }
    }
}
