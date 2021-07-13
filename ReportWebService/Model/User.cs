using ReportWebService.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportWebService.Model
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoginTemplate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual LoginToken LoginToken { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
