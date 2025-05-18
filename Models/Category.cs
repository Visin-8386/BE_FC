using System.ComponentModel.DataAnnotations;

namespace BeeFC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set; } = string.Empty;

        public Category(string name)
        {
            Name = name;
        }

        public Category() { }
    }
}
