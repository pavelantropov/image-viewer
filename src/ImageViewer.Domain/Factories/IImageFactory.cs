using ImageViewer.Domain.Entities;

namespace ImageViewer.Domain.Factories;

public interface IImageFactory
{
	Task<Image> CreateAsync(string name, string description, User uploadedBy, string fileExtension = ".jpeg", CancellationToken cancellationToken = default);
}