using ReportWebService.Model;
using ReportWebService.Repository.Generic;
using System.Collections.Generic;

namespace ReportWebService.Repository
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        List<Tenant> FindByName(string name);

        List<Report> FindAllReportsByTenantID(long tenantId);
    }
}
