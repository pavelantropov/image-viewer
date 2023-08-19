using ImageViewer.Domain.Factories;

namespace ImageViewer.Tests.Domain;

public class Tests
{
	private IImageFactory _imageFactory;

	[SetUp]
	public void Setup()
	{
		// _imageFactory = new ImageFactory();
	}

	[Test]
	public void Create_()
	{
		Assert.Pass();
	}
}