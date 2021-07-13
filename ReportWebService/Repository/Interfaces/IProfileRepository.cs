using ReportWebService.Model;
using ReportWebService.Repository.Generic;
using System.Collections.Generic;

namespace ReportWebService.Repository.Interfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        List<Profile> FindByName(string name);
    }
}
