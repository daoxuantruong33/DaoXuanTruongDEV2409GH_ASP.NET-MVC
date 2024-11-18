using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreMVCLab07.Models
{
    [Table("Products")]
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int ProductSale {  get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string Image {  get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}