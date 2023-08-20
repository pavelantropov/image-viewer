namespace ImageViewer.Domain.Entities;

// TODO
public class User : Entity<int>
{
	public virtual string Name { get; set; }

	public virtual IList<Image> Images { get; set; }
}