using FinancesWPF.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FinancesWPF
{
    public static class UnityConfig
    {
        private static IUnityContainer _container = null;
        public static IUnityContainer ConfigureUnity()
        {
            if (_container != null) return _container;

            _container = new UnityContainer();

            RegisterTypes(_container);

            return _container;
        }

        public static IUnityContainer GetInstance()
            => _container == null ? ConfigureUnity() : _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            var cfg = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("finances.db"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
                .BuildConfiguration();

            var sessionFactory = cfg.BuildSessionFactory();
            container.RegisterInstance(sessionFactory);
            container.RegisterInstance(sessionFactory.OpenSession());
        }

    }
}
