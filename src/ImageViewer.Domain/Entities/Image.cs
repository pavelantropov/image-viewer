namespace ImageViewer.Domain.Entities;

public class Image
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Path { get; set; }
	public DateTime? UploadDate { get; set; }

	public User UploadedBy { get; set; }
}