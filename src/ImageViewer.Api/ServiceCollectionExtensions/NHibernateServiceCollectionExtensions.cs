using System.Data;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using ImageViewer.DataAccess.Repository;
using NHibernate;
using NHibernate.Cfg;
using NLog;
using ISession = NHibernate.ISession;
using ImageViewer.DataAccess.Mappings;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class NHibernateServiceCollectionExtensions
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<INHibernateRepository, NHibernateRepository>();
		services.AddScoped<IAsyncRepository, NHibernateRepository>();

		services.AddSingleton<ISessionFactory>(CreateSessionFactory(configuration));
		services.AddScoped<ISession>(context =>
		{
			var sessionFactory = context.GetService<ISessionFactory>();
			var session = sessionFactory.OpenSession();

			Logger.Trace("Created Session {SessionId}", session.GetSessionImplementation().SessionId);

			return session;
		});

		return services;
	}

	private static ISessionFactory CreateSessionFactory(IConfiguration configuration)
	{
		Logger.Debug("Started creating NHibernate session factory");

		var dbConfig = MsSqlConfiguration
			.MsSql2012
			.ConnectionString(configuration.GetConnectionString("DefaultConnection"))
			.IsolationLevel(IsolationLevel.ReadCommitted)
			.UseReflectionOptimizer()
			.AdoNetBatchSize(100);

		var cfg = Fluently.Configure(new Configuration())
			.Database(dbConfig)
			.Mappings(m => m.FluentMappings
				.AddFromAssemblyOf<ImageMap>());

		var sessionFactory = cfg.BuildSessionFactory();

		Logger.Debug("Finished creating NHibernate session factory");

		return sessionFactory;
	}
}