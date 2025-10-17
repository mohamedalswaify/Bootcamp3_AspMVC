using System.ComponentModel.DataAnnotations;

namespace Bootcamp3_AspMVC.Dtos
{
    public class CategoryDto
    {
        [MaxLength(10)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
