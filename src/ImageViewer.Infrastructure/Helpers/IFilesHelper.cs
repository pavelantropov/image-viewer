using Microsoft.AspNetCore.Http;

namespace ImageViewer.Infrastructure.Helpers;

public interface IFilesHelper
{
	Task<byte[]> ReadFileBytesAsync(string filePath, CancellationToken cancellationToken = default);
	Task CreateFileAsync(string filePath, IFormFile file, CancellationToken cancellationToken = default);
	Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default);
}