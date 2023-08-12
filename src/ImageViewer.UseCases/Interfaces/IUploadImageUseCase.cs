using ImageViewer.UseCases.ApiModels;
using ImageViewer.UseCases.Dto;

namespace ImageViewer.UseCases.Interfaces;

public interface IUploadImageUseCase
{
	Task<ImageDto?> Invoke(
		UploadImageRequestModel request,
		CancellationToken cancellationToken
	);
}