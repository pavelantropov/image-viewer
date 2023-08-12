namespace ImageViewer.DataAccess.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
	void Commit();
}