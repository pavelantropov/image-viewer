using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases;

public interface IDeleteImageUseCase
{
	Task<ImageDto?> Invoke(
		string id,
		CancellationToken cancellationToken
	);
}