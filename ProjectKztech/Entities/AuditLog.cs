using System.ComponentModel.DataAnnotations;
using ProjectKztech.Enums;

namespace ProjectKztech.Entities
{
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Module { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ObjectType { get; set; } = string.Empty;

        // ID object bị thao tác
        public Guid ObjectId { get; set; }

        // Tên hiển thị
        [MaxLength(500)]
        public string? Data { get; set; }

        // ENUM action
        public AuditActionType Action { get; set; }

        // JSON old data
        public string? OldData { get; set; }

        // JSON new data
        public string? NewData { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid? CreatedBy { get; set; }
    }
}