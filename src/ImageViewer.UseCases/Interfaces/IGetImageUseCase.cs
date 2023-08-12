using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IGetImageUseCase
{
	Task<ImageDto?> Invoke(
		string id,
		CancellationToken cancellationToken
	);
}