using CompanyApp.Domain.Enums;
using System.Collections.Generic;

namespace CompanyApp.Domain.Models
{
    public class Store : CompanyBase
    {
        public string Address { get; set; }
        public string Manager { get; set; }
        public double Size { get; set; }
        public StoreType Type { get; set; }
        public ICollection<SupplyActivity> SupplyActivities { get; set; }
    }
}
