using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IGetImageUseCase
{
	Task<ImageDto> Invoke(
		int id,
		CancellationToken cancellationToken = default
	);
}