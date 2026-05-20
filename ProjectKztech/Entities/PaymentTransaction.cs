using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKztech.Entities
{
    public class PaymentTransaction
    {
        [Key]
        public Guid Id { get; set; }

        // FK Contract
        public Guid ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }

        // FK ContractAppendix
        public Guid? AppendixId { get; set; }

        [ForeignKey("AppendixId")]
        public ContractAppendix? Appendix { get; set; }

        [MaxLength(1000)]
        public string? PaymentContent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = 0;

        public DateTime? ReceivedDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}