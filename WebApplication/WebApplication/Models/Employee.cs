using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public partial class Employee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }

        public Employee Manager { get; set; }
        public Department Department { get; set; }
    }
}
