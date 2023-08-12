using NHibernate;

namespace ImageViewer.DataAccess.Repository;

public interface INHibernateRepository : IAsyncRepository
{
	ISession Session { get; }
}