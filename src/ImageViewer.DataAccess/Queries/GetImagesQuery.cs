using ImageViewer.Domain.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace ImageViewer.DataAccess.Queries;

public class GetImagesQuery : IQueryAsync<Image>
{
	private readonly ImageParams _imageParams;

	public GetImagesQuery()
	{
		_imageParams = new ImageParams();
	}

	public async Task<IEnumerable<Image>> ExecuteAsync(ISession session, CancellationToken cancellationToken = default)
	{
		var query = session.QueryOver<Image>();

		query = ApplyFilters(query);

		return await query.ListAsync(cancellationToken);
	}

	private IQueryOver<Image, Image> ApplyFilters(IQueryOver<Image, Image> query)
	{
		var filteredQuery = query.Clone();

		filteredQuery = filteredQuery.ApplyTextFilter(_imageParams.Filter);

		if (_imageParams.Id.HasValue)
			filteredQuery = query.Where(x => x.Id == _imageParams.Id);

		return filteredQuery;
	}

	public class ImageParams
	{
		public string Filter { get; set; }
		public int? Id { get; set; }
	}

	public GetImagesQuery ById(int id)
	{
		_imageParams.Id = id;
		return this;
	}
}

public static class GetImagesQueryExtensions
{
	public static IQueryOver<Image, Image> ApplyTextFilter(this IQueryOver<Image, Image> query, string filter)
	{
		if (string.IsNullOrWhiteSpace(filter)) return query; //!!!

		var filterDisjunction = Restrictions.Disjunction()
			.Add(Restrictions.InsensitiveLike(Projections.Property<Image>(x => x.Id), filter, MatchMode.Exact))
			.Add(Restrictions.InsensitiveLike(Projections.Property<Image>(x => x.Name), filter, MatchMode.Start));

		return query.Where(filterDisjunction);
	}
}