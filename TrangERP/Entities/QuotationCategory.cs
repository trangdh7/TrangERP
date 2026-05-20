using System.ComponentModel.DataAnnotations;

namespace ProjectKztech.Entities
{
    public class QuotationCategory
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

    }
}
