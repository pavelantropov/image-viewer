using System.Data;
using NHibernate;

namespace ImageViewer.DataAccess.UnitOfWork;

public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
{
	private readonly ISessionFactory _sessionFactory;

	public NHibernateUnitOfWorkFactory(ISessionFactory sessionFactory)
	{
		_sessionFactory = sessionFactory;
	}

	public IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) 
		=> new NHibernateUnitOfWork(_sessionFactory.OpenSession(), isolationLevel);
}