using System.Text.RegularExpressions;
using ImageViewer.Domain.Entities;
using ImageViewer.Infrastructure;
using ImageViewer.Infrastructure.Helpers;

namespace ImageViewer.Domain.Factories;

public class ImageFactory : IImageFactory
{
	private readonly IValidationHelper _validationHelper;

	public ImageFactory(IValidationHelper validationHelper)
	{
		_validationHelper = validationHelper;
	}

	public async Task<Image> CreateAsync(string name, string description, User uploadedBy, string fileExtension = ".jpeg")
	{
		var whiteSpacesRegex = new Regex(@"\s+", RegexOptions.Compiled);

		var uniqueFileName = $"{whiteSpacesRegex.Replace(name, string.Empty)}{Guid.NewGuid()}{fileExtension}";
		var imagePath = Path.Combine(FileConstants.ImagesRootPath, uniqueFileName);

		var image = new Image
		{
			Name = name,
			Description = description,
			FileName = uniqueFileName,
			Path = imagePath,
			UploadDate = DateTime.Now,
			UploadedBy = uploadedBy,
		};

		await _validationHelper.ValidateAsync(image);

		return image;
	}
}