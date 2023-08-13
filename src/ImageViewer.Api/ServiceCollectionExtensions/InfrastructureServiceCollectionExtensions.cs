using ImageViewer.Infrastructure.Helpers;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class InfrastructureServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<IFilesHelper, FilesHelper>();

		return services;
	}
}