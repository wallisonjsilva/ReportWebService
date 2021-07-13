using ReportWebService.Model;
using ReportWebService.Model.Context;
using ReportWebService.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace ReportWebService.Repository
{
    public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
    {
        public TenantRepository(MySQLContext context) : base(context) { }

        public List<Tenant> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.Tenants.Where(t => t.TenantName.Contains(name)).ToList();
            }

            return null;
        }

        public List<Report> FindAllReportsByTenantID(long tenantId)
        {
            return _context.Reports.Where(t => t.TenantId.Equals(tenantId)).ToList();
        }
    }
}
