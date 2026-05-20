using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectKztech.Enums;

namespace ProjectKztech.Entities
{
    public class Quotation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string QuotationNo { get; set; } = string.Empty;

        // FK Employee
        public Guid SalesEmployeeId { get; set; }

        [ForeignKey("SalesEmployeeId")]
        public Employee? SalesEmployee { get; set; }

        // FK Customer
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [MaxLength(255)]
        public string? ContactName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        // FK ProductCategory
        public Guid ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0;

        // FK QuotationCategory
        public Guid QuotationCategoryId { get; set; }

        [ForeignKey("QuotationCategoryId")]
        public QuotationCategory? QuotationCategory { get; set; }

        // FK QuotationStatus
        public Guid QuotationStatusId { get; set; }

        [ForeignKey("QuotationStatusId")]
        public QuotationStatus? QuotationStatus { get; set; }

        // ENUM
        public QuotationResult QuotationResult { get; set; } = QuotationResult.Pending;

        public DateTime? ExpectedContractDate { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
