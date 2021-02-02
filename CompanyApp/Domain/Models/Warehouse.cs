using System.Collections.Generic;

namespace CompanyApp.Domain.Models
{
    public class Warehouse : CompanyBase
    {
        public ICollection<SupplyActivity> SupplyActivities { get; set; }
    }
}
