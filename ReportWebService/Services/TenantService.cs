using ReportWebService.Model;
using ReportWebService.Repository;
using ReportWebService.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReportWebService.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;
        private readonly IReportRepository _reportRepository;

        public TenantService(ITenantRepository repository, IReportRepository reportRepository)
        {
            _repository = repository;
            _reportRepository = reportRepository;
        }

        public Tenant Create(Tenant tenant)
        {
            var result = FindByName(tenant.TenantName);

            if (result != null && result.Any()) return null;
            if (tenant.TenantName == null || tenant.TenantName.Trim().Equals("")) return null;

            var tenantEntity = _repository.Create(tenant);
            return tenantEntity;
        }

        public Tenant Update(Tenant tenant)
        {
            var tenantEntity = _repository.Update(tenant);
            return tenantEntity;
        }

        public ICollection<Tenant> FindAll()
        {
            var tenants = _repository.FindAll();

            foreach (var t in tenants)
            {
                var reports = FindAllReportsByTenantID(t.Id);
                t.Reports = reports;
            }

            return tenants;
        }

        public Tenant FindByID(long id)
        {
            var tenant = _repository.FindByID(id);
            var reports = FindAllReportsByTenantID(tenant.Id);
            tenant.Reports = reports;

            return tenant;
        }

        public ICollection<Tenant> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Tenant Disable(long id)
        {
            var tenantEntity = _repository.Disable(id);
            return tenantEntity;
        }

        public Tenant Enable(long id)
        {
            var tenantEntity = _repository.Enable(id);
            return tenantEntity;
        }

        public ICollection<Report> FindAllReportsByTenantID(long tenantId)
        {
            return _repository.FindAllReportsByTenantID(tenantId);
        }
    }
}
