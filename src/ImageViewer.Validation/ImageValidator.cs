using FluentValidation;
using ImageViewer.Domain.Entities;

namespace ImageViewer.Validation;

public class ImageValidator : AbstractValidator<ValidatedObjectWrapper<Image>>
{

}
