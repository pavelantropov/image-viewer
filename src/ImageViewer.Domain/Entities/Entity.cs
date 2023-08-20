namespace ImageViewer.Domain.Entities;

public class Entity<TId> : IEquatable<Entity<TId>>
{
	public virtual TId Id { get; set; }

	public virtual bool Equals(Entity<TId> other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return EqualityComparer<TId>.Default.Equals(Id, other.Id);
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}

		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (obj.GetType() != this.GetType())
		{
			return false;
		}

		return Equals((Entity<TId>)obj);
	}

	public override int GetHashCode()
	{
		return EqualityComparer<TId>.Default.GetHashCode(Id);
	}

	private static bool IsValid(TId id) => id is int || id is long || id is Guid;
}