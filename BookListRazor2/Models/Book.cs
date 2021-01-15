using System.ComponentModel.DataAnnotations;

namespace BookListRazor2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Author { get; set; }
    }
}