namespace ImageViewer.DataAccess.Repository;

public interface IAsyncRepository
{
	// ITransactionManager TransactionManager { get; }

	Task<T> GetAsync<T>(object id, CancellationToken cancellationToken = default) where T : class;

	Task<IList<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class;

	Task<T> SaveAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

	Task<T> SaveOrUpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

	Task DeleteAsync<T>(object id, CancellationToken cancellationToken = default) where T : class;

	Task DeleteAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
}