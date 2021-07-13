using ReportWebService.Model;
using ReportWebService.Model.Context;
using ReportWebService.Repository.Generic;
using ReportWebService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportWebService.Repository
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(MySQLContext context) : base(context) { }

        public List<Report> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.Reports.Where(t => t.ReportName.Contains(name)).ToList();
            }

            return null;
        }

        public Tenant FindTenantByID(long tenantId)
        {
            return _context.Tenants.SingleOrDefault(t => t.Id.Equals(tenantId));
        }
    }
}
