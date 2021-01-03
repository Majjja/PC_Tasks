using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public static class UserHelper
    {
        public static List<User> SetRecipesToUsers(List<Recipe> recipes)
        {
            var users = StaticDB.Users();
            var random = new Random();
            var addedRecipes = new List<int>();

            for (int count = 0; addedRecipes.Count <= recipes.Count; count++)
            {
                if (users[users.Count() - 1].Recipes != null && users[users.Count() - 1].Recipes.Count() == 20) break;

                int i = random.Next(recipes.Count);
                if (addedRecipes.Contains(i)) continue;
                for (int j = 0; j < users.Count; j++)
                {
                    if (users[j].Recipes != null && users[j].Recipes.Count() == 20) continue;
                    if (users[j].Recipes != null && users[j].Recipes.Contains(recipes[i])) continue;

                    if (users[j].Recipes == null)
                        users[j].Recipes = new List<Recipe>();

                    users[j].Recipes.Add(
                        new Recipe()
                        {
                            Id = recipes[i].Id,
                            Name = recipes[i].Name,
                            Instructions = recipes[i].Instructions,
                            ServingQuantity = recipes[i].ServingQuantity,
                            Notes = recipes[i].Notes,
                            SkillLevel = recipes[i].SkillLevel,
                            PreparingTime = recipes[i].PreparingTime
                        });
                    break;
                }
                addedRecipes.Add(i);
            }
            return users;
        }
    }
}
