using FinancesWPF.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancesWPF.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
