using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases;

public interface IGetImageUseCase
{
	Task<ImageDto?> Invoke(
		string id,
		CancellationToken cancellationToken
	);
}