using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportWebService.Model.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public bool Disable { get; set; }
    }
}
