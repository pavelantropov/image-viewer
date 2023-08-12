using Ninject.Modules;
using Ninject.Web.Common;
using NLog;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using ImageViewer.DataAccess.Repository;
using ISession = NHibernate.ISession;
using FluentNHibernate.Conventions.Helpers;
using ImageViewer.DataAccess.UnitOfWork;

namespace ImageViewer.Api.App_Start.NinjectModules;

public class NHibernateModule : NinjectModule
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public override void Load()
	{
		Bind<IUnitOfWorkFactory>().To<NHibernateUnitOfWorkFactory>();

		Bind<ISessionFactory>().ToMethod(_ => CreateSessionFactory()).InSingletonScope();

		Bind<INHibernateRepository>().To<NHibernateRepository>().InRequestScope();
		Bind<IAsyncRepository>().To<NHibernateRepository>().InRequestScope();

		Bind<ISession>().ToMethod(context =>
		{
			var sessionFactory = context.Kernel.GetService<ISessionFactory>();
			var session = sessionFactory.OpenSession();

			Logger.Trace("Created Session {SessionId}", session.GetSessionImplementation().SessionId);

			return session;
		}).InRequestScope();
	}

	private static ISessionFactory CreateSessionFactory()
	{
		Logger.Debug("Started creating NHibernate session factory");

		var dbConfig = MsSqlConfiguration
			.MsSql2012
			.ConnectionString(x => x.FromConnectionStringWithKey("MSSQL"))
			.UseReflectionOptimizer()
			.AdoNetBatchSize(100);

		var configuration = new Configuration();

		var cfg = Fluently.Configure(configuration)
			.Database(dbConfig)
			.Mappings(m => m.FluentMappings
				.Conventions.Add(
					ConventionBuilder.Class.Always(x => x.Table(x.EntityType.Name))));

		var sessionFactory = cfg.BuildSessionFactory();

		Logger.Debug("Finished creating NHibernate session factory");

		return sessionFactory;
	}
}