namespace ImageViewer.Domain.Entities;

public class Image
{
	public virtual int Id { get; set; }
	public virtual string Name { get; set; }
	public virtual string Description { get; set; }
	public virtual string Path { get; set; }
	public virtual DateTime? UploadDate { get; set; }

	public virtual User UploadedBy { get; set; }
}