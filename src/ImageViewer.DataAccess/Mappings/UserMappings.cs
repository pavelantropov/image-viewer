using FluentNHibernate.Mapping;
using ImageViewer.Domain.Entities;

namespace ImageViewer.DataAccess.Mappings;

public class UserMappings : ClassMap<User>
{
	public UserMappings()
	{
		Table("Users");

		Id(x => x.Id);

		Map(x => x.Name);

		HasMany(x => x.Images).KeyColumn("uploaded_by").Cascade.AllDeleteOrphan();
	}
}