using NHibernate;

namespace ImageViewer.DataAccess.Repository;

public class NHibernateRepository : INHibernateRepository
{
	public ISession Session { get; }

	// public ITransactionManager TransactionManager { get; }

	public NHibernateRepository(ISession session)
	{
		Session = session;
	}

	public Task<T> GetAsync<T>(object id, CancellationToken cancellationToken = default) where T : class
	{
		return Session.GetAsync<T>(id, cancellationToken);
	}

	public Task<IList<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class
	{
		return Session.QueryOver<T>()
			.Cacheable()
			.ListAsync<T>(cancellationToken);
	}

	public async Task<T> SaveAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
	{
		await Session.SaveAsync(entity, cancellationToken).ConfigureAwait(false);
		return entity;
	}

	public async Task<T> SaveOrUpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
	{
		await Session.SaveOrUpdateAsync(entity, cancellationToken).ConfigureAwait(false);
		return entity;
	}

	public async Task DeleteAsync<T>(object id, CancellationToken cancellationToken = default) where T : class
	{
		var entity = await GetAsync<T>(id, cancellationToken).ConfigureAwait(false);
		if (entity != null) await DeleteAsync(entity, cancellationToken).ConfigureAwait(false);
	}

	public Task DeleteAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
	{
		return Session.DeleteAsync(entity, cancellationToken);
	}

	public Task FlushAsync(CancellationToken cancellationToken = default)
	{
		return Session.FlushAsync(cancellationToken);
	}
}