using System.Text.RegularExpressions;
using ImageViewer.Domain.Entities;
using ImageViewer.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;

namespace ImageViewer.Domain.Factories;

public class ImageFactory : IImageFactory
{
	private readonly IValidationHelper _validationHelper;
	private readonly IConfiguration _configuration;

	public ImageFactory(IValidationHelper validationHelper,
		IConfiguration configuration)
	{
		_validationHelper = validationHelper;
		_configuration = configuration;
	}

	public async Task<Image> CreateAsync(string name, string description, User uploadedBy, string fileExtension = ".jpeg", CancellationToken cancellationToken = default)
	{
		var whiteSpacesRegex = new Regex(@"\s+", RegexOptions.Compiled);

		var uniqueFileName = $"{whiteSpacesRegex.Replace(name, string.Empty)}{Guid.NewGuid()}{fileExtension}";
		var imagePath = Path.Combine(_configuration.GetSection("ImagesRootPath").Value, uniqueFileName);

		var image = new Image
		{
			Name = name,
			Description = description,
			FileName = uniqueFileName,
			Path = imagePath,
			UploadDate = DateTime.Now,
			UploadedBy = uploadedBy,
		};

		await _validationHelper.ValidateAsync(image, cancellationToken);

		return image;
	}
}