using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IGetListOfImagesUseCase
{
	Task<ImagesDto> Invoke(
		string filter,
		CancellationToken cancellationToken = default
	);
}