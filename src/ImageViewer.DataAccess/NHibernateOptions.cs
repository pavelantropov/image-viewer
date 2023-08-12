namespace ImageViewer.DataAccess;

public record NHibernateOptions
{
	public string ConnectionString { get; set; }
	public string DbName { get; set; }
}