using FinancesWPF.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesWPF.Repositories
{
    public class MovementRepository : IRepository<Movement>
    {
        private readonly ISession _session;

        public MovementRepository(ISession session)
        {
            _session = session;
        }

        public Movement Create(Movement entity)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                _session.Save(entity);
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

            return entity;
        }

        public void Delete(int id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var category = _session.Get<Category>(id);
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

        public Movement Get(int id)
            => _session.Get<Movement>(id);

        public IEnumerable<Movement> GetAll()
            => _session.Query<Movement>().ToList();

        public void Update(Movement entity)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                _session.Delete(entity);
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
