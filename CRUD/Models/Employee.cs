using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be biger than 3 chars.")]
        public string Name { get; set; }
        [Range(9000, 12000, ErrorMessage = "Salary must be between 9000 and 12000.")]
        public int Salary { get; set; }
        public int Age { get; set; }
    }
}
