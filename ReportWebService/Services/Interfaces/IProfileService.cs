using ReportWebService.Model;
using System.Collections.Generic;

namespace ReportWebService.Services.Interfaces
{
    public interface IProfileService
    {
        Profile Create(Profile report);

        Profile FindByID(long id);

        ICollection<Profile> FindByName(string name);

        ICollection<Profile> FindAll();

        Profile Update(Profile report);

        Profile Disable(long id);

        Profile Enable(long id);

        void Delete(long id);
    }
}
