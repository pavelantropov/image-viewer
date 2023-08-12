using FluentNHibernate.Mapping;
using ImageViewer.Domain.Entities;

namespace ImageViewer.DataAccess.Mappings;

public class ImageMappings : ClassMap<Image>
{
	public ImageMappings()
	{
		Table("Images");

		Id(x => x.Id);

		Map(x => x.Name);
		Map(x => x.Description);
		Map(x => x.Path);
		Map(x => x.UploadDate);

		References(x => x.UploadedBy);
	}
}