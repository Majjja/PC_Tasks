using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using System.IO;
using System.Linq;
using System.Globalization;
using CsvHelper;
using Services.CsvMapping;

namespace Services.Helpers
{
    public static class ProccessRecipes
    {
        public static List<Recipe> GetRecipes(string path)
        {
            var recipes = new List<Recipe>();
            using(var sr = new StreamReader(path))
            {
                using(var csv = new CsvReader(sr, CultureInfo.CurrentCulture))
                {
                    csv.Configuration.RegisterClassMap<RecipeMap>();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Recipe>();
                        recipes.Add(record);
                    }
                }
            }
            return recipes;
        }
    }
}
