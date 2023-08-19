using ImageViewer.Domain.Factories;

namespace ImageViewer.Api.ServiceCollectionExtensions;

public static class DomainServiceCollectionExtensions
{
	public static IServiceCollection AddFactories(this IServiceCollection services)
	{
		services.AddScoped<IImageFactory, ImageFactory>();

		return services;
	}
}