using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IDeleteImageUseCase
{
	Task<ImageDto?> Invoke(
		string id,
		CancellationToken cancellationToken
	);
}