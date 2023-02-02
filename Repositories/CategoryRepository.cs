using FinancesWPF.Entities;
using NHibernate;
using System;

namespace FinancesWPF.Repositories
{
    public class CategoryRepository : ICategoryRespository
    {
        private readonly ISession _session;

        public CategoryRepository(ISession session) =>
            _session = session;

        public Category Create(Category category)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                _session.Save(category);
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
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
