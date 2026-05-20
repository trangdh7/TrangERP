using System.ComponentModel.DataAnnotations;

namespace ProjectKztech.Entities
{
    public class QuotationStatus
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
         [MaxLength(255)]
        public string StatusName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

    }
}
