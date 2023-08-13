using FluentNHibernate.Mapping;
using ImageViewer.Domain.Entities;

namespace ImageViewer.DataAccess.Mappings;

public class UserMap : ClassMap<User>
{
	public UserMap()
	{
		Table("Users");

		Id(x => x.Id).GeneratedBy.Identity();

		Map(x => x.Name);

		HasMany(x => x.Images).KeyColumn("UploadedBy_id").Cascade.AllDeleteOrphan();
	}
}