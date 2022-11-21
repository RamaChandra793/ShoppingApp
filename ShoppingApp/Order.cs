using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
