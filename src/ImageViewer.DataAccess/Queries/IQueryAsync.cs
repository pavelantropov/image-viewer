using NHibernate;

namespace ImageViewer.DataAccess.Queries;

public interface IQueryAsync<T>
{
	Task<IEnumerable<T>> ExecuteAsync(ISession session, CancellationToken cancellationToken);
}