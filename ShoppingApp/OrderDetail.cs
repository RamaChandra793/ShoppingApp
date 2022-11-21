using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public int ProductQty { get; set; }
        public int ProductPrice { get; set; }
        public int OrderId { get; set; }
    }
}
