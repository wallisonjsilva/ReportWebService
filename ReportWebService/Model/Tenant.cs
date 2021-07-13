using ReportWebService.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportWebService.Model
{
    public class Tenant : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string TenantName { get; set; }

        [Required]
        public string TenantAzureId { get; set; }

        [Required]
        public string ClientAzureId { get; set; }

        [ForeignKey("TenantId")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
