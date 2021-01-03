using CsvHelper.Configuration;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CsvMapping
{
    public class RecipeMap : ClassMap<Recipe>
    {
        public RecipeMap()
        {
            Map(member => member.Id).Name("Id");
            Map(member => member.Name).Name("Name");
            Map(member => member.Instructions).Name("Instructions");
            Map(member => member.ServingQuantity).Name("Quantity");
            Map(member => member.Notes).Name("Notes");
            Map(member => member.SkillLevel).Name("SkillLevel");
            Map(member => member.PreparingTime).Name("PreparingTime");
        }
    }
}
