using System.Data;

namespace ImageViewer.DataAccess.UnitOfWork;

public interface IUnitOfWorkFactory
{
	IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
}