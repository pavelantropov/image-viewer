using ImageViewer.Domain.Entities;

namespace ImageViewer.UseCases.Dto;

public class ImageDto
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Path { get; set; }
	public DateTime? UploadDate { get; set; }
	public User UploadedBy { get; set; }

	public byte[] Content { get; set; }
}