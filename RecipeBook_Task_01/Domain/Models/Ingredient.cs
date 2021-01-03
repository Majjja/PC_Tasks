using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Ingredient : BaseClass
    {
        public int QuantityAvailable { get; set; }
        public Unit Unit { get; set; }

    }
}
