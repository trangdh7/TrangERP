using System.ComponentModel.DataAnnotations;

namespace ProjectKztech.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        // Reference to user table account of sales employee.
        public Guid UserId { get; set; }

        [MaxLength(100)]
        public string? EmployeeCode { get; set; }

        [MaxLength(255)]
        public string? FullName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
