using ImageViewer.UseCases;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class UseCasesServiceCollectionExtensions
{
	public static IServiceCollection AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<IGetImageUseCase, GetImageUseCase>();
		services.AddScoped<IGetListOfImagesUseCase, GetListOfImagesUseCase>();
		services.AddScoped<IDeleteImageUseCase, DeleteImageUseCase>();
		services.AddScoped<IUploadImageUseCase, UploadImageUseCase>();

		return services;
	}
}