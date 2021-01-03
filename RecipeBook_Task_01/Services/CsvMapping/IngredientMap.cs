using CsvHelper.Configuration;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CsvMapping
{
    public class IngredientMap : ClassMap<Ingredient>
    {
        public IngredientMap()
        {
            Map(member => member.Id).Name("Id");
            Map(member => member.Name).Name("Name");
            Map(member => member.QuantityAvailable).Name("Quantity");
            Map(member => member.Unit).Name("Unit");
        }
    }
}
