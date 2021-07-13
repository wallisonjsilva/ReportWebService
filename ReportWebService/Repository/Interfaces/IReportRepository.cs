using ReportWebService.Model;
using ReportWebService.Repository.Generic;
using System.Collections.Generic;

namespace ReportWebService.Repository.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        List<Report> FindByName(string name);

        Tenant FindTenantByID(long tenantId);
    }
}
