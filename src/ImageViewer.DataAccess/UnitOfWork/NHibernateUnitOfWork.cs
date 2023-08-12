using System.Data;
using NHibernate;
using NHibernate.Context;

namespace ImageViewer.DataAccess.UnitOfWork;

public class NHibernateUnitOfWork : IUnitOfWork
{
	private readonly ISession _session;
	private readonly ITransaction _transaction;

	public NHibernateUnitOfWork(ISession session,
		IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
	{
		CurrentSessionContext.Bind(session);

		_session = session;
		_transaction = _session.BeginTransaction(isolationLevel);
	}

	public void Dispose()
	{
		if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
		{
			_transaction.Rollback();
		}
		_transaction.Dispose();

		CurrentSessionContext.Unbind(_session.SessionFactory);
		_session.Dispose();
	}

	public void Commit()
	{
		if (_transaction.IsActive)
		{
			_transaction.Commit();
		}
	}
}