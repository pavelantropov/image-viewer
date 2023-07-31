using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases;

public interface IPostImageUseCase
{
	Task<ImageDto?> Invoke(
		ImageDto imageDto,
		CancellationToken cancellationToken
	);
}