namespace ImageViewer.UseCases.Interfaces;

public interface IDeleteImageUseCase
{
	Task Invoke(
		int id,
		CancellationToken cancellationToken = default
	);
}