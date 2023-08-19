using FluentValidation;
using ImageViewer.Domain.Entities;

namespace ImageViewer.Tests.Validation;

public class ImageValidatorTests
{
	private readonly AbstractValidator<Image> _imageValidator;

	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void Test1()
	{
		Assert.Pass();
	}
}