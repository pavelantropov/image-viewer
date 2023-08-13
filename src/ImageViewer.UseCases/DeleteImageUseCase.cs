using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.Infrastructure.Helpers;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class DeleteImageUseCase : IDeleteImageUseCase
{
	private readonly INHibernateRepository _repository;
	private readonly IFilesHelper _filesHelper;

	public DeleteImageUseCase(INHibernateRepository repository,
		IFilesHelper filesHelper)
	{
		_repository = repository;
		_filesHelper = filesHelper;
	}

	public async Task Invoke(int id, CancellationToken cancellationToken = default)
	{
		var image = await _repository.GetAsync<Image>(id, cancellationToken);

		if (image == null)
		{
			// TODO
			return;
		}

		await _repository.DeleteAsync<Image>(id, cancellationToken);
		await _filesHelper.DeleteFileAsync(image.Path, cancellationToken);
		await _repository.FlushAsync(cancellationToken);
	}
}