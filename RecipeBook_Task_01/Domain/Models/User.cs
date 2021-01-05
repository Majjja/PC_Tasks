using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : BaseClass
    {
        public new int Id { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
