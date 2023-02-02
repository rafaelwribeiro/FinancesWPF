using FinancesWPF.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancesWPF.Repositories
{
    public interface ICategoryRespository
    {
        Category Create(Category category);
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Update(Category category);
        void Delete(int id);
    }
}
