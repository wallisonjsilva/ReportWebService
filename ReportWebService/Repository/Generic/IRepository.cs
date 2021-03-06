using ReportWebService.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportWebService.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T FindByID(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        T Disable(long id);

        T Enable(long id);

        bool Exists(long id);

        List<T> FindWithPagedSearch(string query);

        int GetCount(string query);
    }
}
