using ReportWebService.Model;
using System.Collections.Generic;

namespace ReportWebService.Services.Interfaces
{
    public interface IReportService
    {
        Report Create(Report report);

        Report FindByID(long id);

        ICollection<Report> FindByName(string name);

        ICollection<Report> FindAll();

        Tenant FindTenantByID(long tenantId);

        Report Update(Report report);

        Report Disable(long id);

        Report Enable(long id);

        void Delete(long id);
    }
}
