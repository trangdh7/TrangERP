using ProjectKztech.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectKztech.Entities
{
    public class Project
    {
        [Key]          
        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProjectCode { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; } = string.Empty ;
       
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [MaxLength(1000)]
        public string? Description {  get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.Planning;

        public Guid? OwnerEmployeeId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }


    }
}
