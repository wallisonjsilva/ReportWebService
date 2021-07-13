using ReportWebService.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportWebService.Model
{
    public class Profile : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        public string ProfileName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
