using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectKztech.Enums;

namespace ProjectKztech.Entities
{
    public class ContractAppendix
    {
        [Key]
        public Guid Id { get; set; }

        // FK Contract
        public Guid ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }

        [Required]
        [MaxLength(255)]
        public string AppendixName { get; set; } = string.Empty;

        // text
        public string? Content { get; set; }

        // FK ProductCategory
        public Guid? ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AppendixValue { get; set; } = 0;

        public DateTime? PaymentDueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualReceivedAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingAmount { get; set; } = 0;

        // ENUM
        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.NOT_SENT;

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}