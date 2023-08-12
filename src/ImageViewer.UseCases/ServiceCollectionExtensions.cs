using ImageViewer.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ImageViewer.UseCases;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddUseCases(this IServiceCollection services)
	{
		services.AddTransient<IGetImageUseCase, GetImageUseCase>();
		services.AddTransient<IGetListOfImagesUseCase, GetListOfImagesUseCase>();
		services.AddTransient<IDeleteImageUseCase, DeleteImageUseCase>();
		services.AddTransient<IPostImageUseCase, PostImageUseCase>();

		return services;
	}
}