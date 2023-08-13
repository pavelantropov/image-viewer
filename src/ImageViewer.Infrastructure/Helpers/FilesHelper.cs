using System.Threading;
using Microsoft.AspNetCore.Http;

namespace ImageViewer.Infrastructure.Helpers;

public class FilesHelper : IFilesHelper
{
	public async Task<byte[]> ReadFileBytesAsync(string filePath, CancellationToken cancellationToken = default)
	{


		return File.Exists(filePath)
			? await File.ReadAllBytesAsync(filePath, cancellationToken)
			: throw new FileNotFoundException($"File not found.", filePath);
			//: throw new FileNotFoundException($"File {image.Name} not found.", image.Name);
	}

	public async Task CreateFileAsync(string filePath, IFormFile file, CancellationToken cancellationToken = default)
	{
		await using var stream = new FileStream(filePath, FileMode.Create);
		await file.CopyToAsync(stream, cancellationToken);
	}

	public async Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default)
	{
		File.Delete(filePath);
	}
}