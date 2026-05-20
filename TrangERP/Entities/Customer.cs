using System.ComponentModel.DataAnnotations;

namespace ProjectKztech.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(255)]
        public string? ContactName { get; set; }

        public DateTime? Dob {  get; set; }
        [MaxLength(20)]
        public string? Phone {  get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        public string? Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }




    }
}
