using ReportWebService.Model;
using ReportWebService.Repository.Interfaces;
using ReportWebService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReportWebService.Services
{
    public class ProfileService : IProfileService
    {

        private readonly IProfileRepository _repository;

        public ProfileService(IProfileRepository repository)
        {
            _repository = repository;
        }


        public Profile Create(Profile profile)
        {
            var result = FindByName(profile.ProfileName);

            if (result != null && result.Any()) return null;
            if (profile.ProfileName == null || profile.ProfileName.Trim().Equals("")) return null;

            var profileEntity = _repository.Create(profile);
            return profileEntity;  
        }

        public Profile FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public ICollection<Profile> FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public ICollection<Profile> FindAll()
        {
            return _repository.FindAll();
        }

        public Profile Update(Profile report)
        {
            var profileEntity = _repository.Update(report);
            return profileEntity;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Profile Disable(long id)
        {
            var profileEntity = _repository.Disable(id);
            return profileEntity;
        }

        public Profile Enable(long id)
        {
            var profileEntity = _repository.Enable(id);
            return profileEntity;
        }
    }
}
