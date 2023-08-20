namespace ImageViewer.Domain.Entities;

public class Image : Entity<int>
{
	public virtual string Name { get; set; }
	public virtual string Description { get; set; }
	public virtual string FileName { get; set; }
	public virtual string Path { get; set; }
	public virtual DateTime? UploadDate { get; set; }

	public virtual User UploadedBy { get; set; }
}