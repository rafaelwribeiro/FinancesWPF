using FinancesWPF.Entities;
using FinancesWPF.Mapping;
using FinancesWPF.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
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
        public static IUnityContainer GetContainer()
            => _container == null ? ConfigureUnity() : _container;

        private static IUnityContainer ConfigureUnity()
        {
            if (_container != null) return _container;

            _container = new UnityContainer();

            RegisterTypes(_container);

            return _container;
        }

        public static T Resolve<T>()
        {
            return GetContainer().Resolve<T>();
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            var cfg = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("finances.db"))
                .Mappings(m => {
                    m.FluentMappings.AddFromAssemblyOf<CategoryMap>();
                    m.FluentMappings.AddFromAssemblyOf<MovementMap>();
                })
                .BuildConfiguration();
            cfg.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlAuto, "update");

            var schemaExport = new SchemaExport(cfg);
            schemaExport.Create(false, true);

            var sessionFactory = cfg.BuildSessionFactory();
            container.RegisterInstance(sessionFactory);
            container.RegisterInstance(sessionFactory.OpenSession());

            container.RegisterType<IRepository<Category>, CategoryRepository>();
            container.RegisterType<IRepository<Movement>, MovementRepository>();
        }

    }
}
