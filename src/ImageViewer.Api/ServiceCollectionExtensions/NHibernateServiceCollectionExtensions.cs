using System.Data;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using ImageViewer.DataAccess.Repository;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NLog;
using ISession = NHibernate.ISession;
using ImageViewer.DataAccess.Mappings;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class NHibernateServiceCollectionExtensions
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static IServiceCollection AddNHibernate(this IServiceCollection services, ConfigurationManager configuration)
	{
		// services.Configure<NHibernateOptions>(
		// 	configuration.GetSection("NHibernate"));

		services.AddScoped<INHibernateRepository, NHibernateRepository>();
		services.AddScoped<IAsyncRepository, NHibernateRepository>();

		services.AddSingleton<ISessionFactory>(CreateSessionFactory());
		services.AddScoped<ISession>(context =>
		{
			var sessionFactory = context.GetService<ISessionFactory>();
			var session = sessionFactory.OpenSession();

			Logger.Trace("Created Session {SessionId}", session.GetSessionImplementation().SessionId);

			return session;
		});

		return services;
	}

	private static ISessionFactory CreateSessionFactory()
	{
		Logger.Debug("Started creating NHibernate session factory");

		var dbConfig = MsSqlConfiguration
			.MsSql2012
			.ConnectionString("data source=DESKTOP-95CMJVH;initial catalog=ImageViewerDb;trusted_connection=true")
			.IsolationLevel(IsolationLevel.ReadCommitted)
			// .UseReflectionOptimizer()
			.AdoNetBatchSize(100);

		var configuration = new Configuration();

		var cfg = Fluently.Configure(configuration)
			.Database(dbConfig)
			.Mappings(m => m.FluentMappings
				.AddFromAssemblyOf<ImageMap>());
				// .Conventions.Add(
				// 	ConventionBuilder.Class.Always(x => x.Table(x.EntityType.Name))));

		var sessionFactory = cfg.BuildSessionFactory();

		Logger.Debug("Finished creating NHibernate session factory");

		return sessionFactory;
	}
}