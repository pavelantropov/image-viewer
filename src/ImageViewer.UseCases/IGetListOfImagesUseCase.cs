using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases;

public interface IGetListOfImagesUseCase
{
	Task<ImagesDto> Invoke(
		string? filter,
		CancellationToken cancellationToken
	);
}