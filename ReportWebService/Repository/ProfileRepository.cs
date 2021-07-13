using ReportWebService.Model;
using ReportWebService.Model.Context;
using ReportWebService.Repository.Generic;
using ReportWebService.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReportWebService.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(MySQLContext context) : base(context) { }

        public List<Profile> FindByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return _context.Profiles.Where(t => t.ProfileName.Contains(name)).ToList();
            }

            return null;
        }
    }
}
