namespace ImageViewer.Domain.Entities;

// Вместо юзера использовать куки и middleware
public class User
{
	public virtual int Id { get; set; }
	public virtual string Name { get; set; }

	public virtual IList<Image> Images { get; set; }
}