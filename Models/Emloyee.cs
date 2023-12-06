using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employees_CRUD.Models
{
    public class Emloyee
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public  int ManagerId { get; set; }       
        public string? IsActive { get; set; }        
        public string? StartingDate { get; set; }
    }
}
