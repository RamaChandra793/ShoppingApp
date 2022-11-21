using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string CustomerEmail { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string CustomerPassword { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public int CustomerPostalCode { get; set; }
    }
}

