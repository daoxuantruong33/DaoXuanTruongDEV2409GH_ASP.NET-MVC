using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sesson06.TheoryCF8.Models.DataModels
{
    [Table("Book")]

    public class Book
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
    }
}
