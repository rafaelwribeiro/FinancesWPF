using FinancesWPF.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesWPF.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ISession _session;

        public CategoryRepository(ISession session) =>
            _session = session;

        public Category Create(Category entity)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                _session.Save(entity);
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

            return entity;
        }

        public void Delete(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var category =  _session.Get<Category>(id);
                _session.Delete(category);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public Category Get(int id)
            => _session.Get<Category>(id);

        public IEnumerable<Category> GetAll()
            => _session.Query<Category>().ToList();

        public void Update(Category entity)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                _session.Update(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
