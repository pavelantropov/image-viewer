namespace ImageViewer.Infrastructure.Helpers;

public interface IValidationHelper
{
	Task ValidateAsync<T>(T value, CancellationToken cancellationToken = default);
}