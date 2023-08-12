namespace ImageViewer.UseCases.Dto;

public class ImagesDto
{
	public ImageDto[] Images { get; set; } = null!;
	public int ImagesCount { get; set; }
}