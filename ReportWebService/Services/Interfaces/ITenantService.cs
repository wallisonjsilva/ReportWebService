using ReportWebService.Model;
using System.Collections.Generic;

namespace ReportWebService.Services
{
    public interface ITenantService
    {
        Tenant Create(Tenant tenant);

        Tenant FindByID(long id);

        ICollection<Tenant> FindByName(string name);

        ICollection<Tenant> FindAll();

        ICollection<Report> FindAllReportsByTenantID(long tenantId);

        Tenant Update(Tenant tenant);

        Tenant Disable(long id);

        Tenant Enable(long id);

        void Delete(long id);
    }
}
