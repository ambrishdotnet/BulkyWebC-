using System.ComponentModel.DataAnnotations;

namespace BulkyWebC_.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int CategoryOrder { get; set; }
    }
}
