using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Recipe : BaseClass
    {
        public string Instructions { get; set; }
        public ServingQuantity ServingQuantity { get; set; }
        public string Notes { get; set; }
        public double SkillLevel { get; set; }
        public int PreparingTime { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
