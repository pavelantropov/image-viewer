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
		RuleFor(x => x.Path)
			.Must(p => !p.Any(char.IsWhiteSpace))
			.WithMessage("The file must not contain whitespaces.");
		RuleFor(x => x.Path)
			.Must(p => Path.GetExtension(p) != string.Empty)
			.WithMessage("The file must have a valid extension.");
	}
}