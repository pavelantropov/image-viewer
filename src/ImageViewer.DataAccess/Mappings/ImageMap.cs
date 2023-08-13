using FluentNHibernate.Mapping;
using ImageViewer.Domain.Entities;

namespace ImageViewer.DataAccess.Mappings;

public class ImageMap : ClassMap<Image>
{
	public ImageMap()
	{
		Table("Images");

		Id(x => x.Id).GeneratedBy.Identity();

		Map(x => x.Name);
		Map(x => x.Description);
		Map(x => x.Path);
		Map(x => x.FileName);
		Map(x => x.UploadDate).Not.Update();

		References(x => x.UploadedBy).Not.Update();
	}
}