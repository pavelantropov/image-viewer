using ImageViewer.Infrastructure.Helpers;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class InfrastructureServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped<IFilesHelper, FilesHelper>();
		services.AddScoped<IValidationHelper, ValidationHelper>();

		return services;
	}
}