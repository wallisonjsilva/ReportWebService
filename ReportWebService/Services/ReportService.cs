using ReportWebService.Model;
using ReportWebService.Repository.Interfaces;
using ReportWebService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReportWebService.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public Report Create(Report report)
        {
            var result = FindByName(report.ReportName);

            if (result != null && result.Any()) return null;
            if (report.ReportName == null || report.ReportName.Trim().Equals("")) return null;

            var reportEntity =  _repository.Create(report);
            return reportEntity;
        }

        public Report Update(Report report)
        {
            var reportEntity = _repository.Update(report);
            return reportEntity;
        }

        public ICollection<Report> FindAll()
        {
            
            var reports = _repository.FindAll();

            foreach (var r in reports)
            {
                var tenant = FindTenantByID(r.TenantId);
                r.Tenant = tenant;
            }

            return reports;
        }

        public Report FindByID(long id)
        {
            var report = _repository.FindByID(id);
            var tenant = FindTenantByID(report.TenantId);
            report.Tenant = tenant;

            return report;
        }

        public ICollection<Report> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Report Disable(long id)
        {
            var reportEntity = _repository.Disable(id);
            return reportEntity;
        }

        public Report Enable(long id)
        {
            var reportEntity = _repository.Enable(id);
            return reportEntity;
        }

        public Tenant FindTenantByID(long tenantId)
        {
            return _repository.FindTenantByID(tenantId);
        }
    }
}
