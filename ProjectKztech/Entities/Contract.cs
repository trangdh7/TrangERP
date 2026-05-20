using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKztech.Entities
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContractNo { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? ContractCode { get; set; }

        // FK ContractType
        public Guid ContractTypeId { get; set; }

        [ForeignKey("ContractTypeId")]
        public ContractType? ContractType { get; set; }

        // FK Quotation
        public Guid? QuotationId { get; set; }

        [ForeignKey("QuotationId")]
        public Quotation? Quotation { get; set; }

        public DateTime SignDate { get; set; }

        // FK Customer
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        // FK Contact
        public Guid? ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact? Contact { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImplementationPeriod { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string MaintenancePeriod { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string ImplementationStages { get; set; } = string.Empty;

        public string? ContractContent { get; set; }

        // FK ProductCategory
        public Guid ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }

        [Required]
        [MaxLength(500)]
        public string DeliveryAddress { get; set; } = string.Empty;

        // FK Employee
        public Guid SalesEmployeeId { get; set; }

        [ForeignKey("SalesEmployeeId")]
        public Employee? SalesEmployee { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContractStatus { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountBeforeVat { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal VatAmount { get; set; } = 0;

        [MaxLength(1000)]
        public string? PaymentTerms { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LiquidationAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualReceivedAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingAmount { get; set; } = 0;

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}