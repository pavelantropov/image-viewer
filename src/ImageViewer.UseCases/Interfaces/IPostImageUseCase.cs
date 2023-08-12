using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IPostImageUseCase
{
	Task<ImageDto?> Invoke(
		ImageDto imageDto,
		CancellationToken cancellationToken
	);
}