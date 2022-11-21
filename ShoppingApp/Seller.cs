using System.ComponentModel.DataAnnotations;

namespace ShoppingApp
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string SellerEmail { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string SellerPassword { get; set; }
    }

}