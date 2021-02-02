using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApp.Domain.Models
{
    public class SupplyActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSupply { get; set; }
    }
}
