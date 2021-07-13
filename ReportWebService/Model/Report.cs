using ReportWebService.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportWebService.Model
{
    public class Report : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string ReportName { get; set; }

        [Required]
        public string WorkspaceAzureId { get; set; }

        [Required]
        public string ReportAzureId { get; set; }

        [ForeignKey("Tenant")]
        public long TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}