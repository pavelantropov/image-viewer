using FluentValidation;
using ImageViewer.Domain.Entities;

namespace ImageViewer.Validation.Validators;

public class ImageValidator : AbstractValidator<Image>
{
	public ImageValidator()
	{
		RuleFor(x => x.Name).NotNull().NotEmpty();
		RuleFor(x => x.Path).NotNull().NotEmpty();
		RuleFor(x => x.UploadDate).NotNull().LessThan(DateTime.Now);
	}
}