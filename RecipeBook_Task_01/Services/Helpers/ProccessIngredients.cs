using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using CsvHelper;
using Services.CsvMapping;

namespace Services.Helpers
{
    public static class ProccessIngredients
    {
        public static List<Ingredient> GetIngredients(string path)
        {
            var list = new List<Ingredient>();
            using(var sr = new StreamReader(path))
            {
                using(var csv = new CsvReader(sr, CultureInfo.CurrentCulture))
                {
                    csv.Configuration.RegisterClassMap<IngredientMap>();
                    while (csv.Read())
                    {
                        var records = csv.GetRecord<Ingredient>();
                        list.Add(records);
                    }
                }
            }
            return list;
        }
    }
}
