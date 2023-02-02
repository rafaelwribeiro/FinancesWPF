using FinancesWPF.Entities;
using System.Threading.Tasks;

namespace FinancesWPF.Repositories
{
    public interface ICategoryRespository
    {
        Task<Category> Create(Category category);
    }
}
