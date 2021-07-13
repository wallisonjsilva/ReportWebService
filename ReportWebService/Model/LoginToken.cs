
using ReportWebService.Model.Base;
using System.Collections.Generic;

namespace ReportWebService.Model
{
    public class LoginToken : BaseEntity
    {
        public string NameLocalLogin { get; set; }

        public string RefreshToken { get; set; }

        public string RefreshTokenExpiryTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
