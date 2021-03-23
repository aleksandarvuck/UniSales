using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniSales.API.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderTotal { get; set; }

        public List<Product> Products { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }
    }
}