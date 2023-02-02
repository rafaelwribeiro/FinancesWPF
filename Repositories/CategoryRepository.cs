using FinancesWPF.Entities;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace FinancesWPF.Repositories
{
    public class CategoryRepository : ICategoryRespository
    {
        private readonly ISession _session;

        public CategoryRepository(ISession session) =>
            _session = session;

        public async Task<Category> Create(Category category)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(category);
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
            finally
            {
                transaction?.Dispose();
            }

            return category;
        }
    }
}
