using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class DeleteImageUseCase : IDeleteImageUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;

	public DeleteImageUseCase(IAsyncRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task Invoke(int id, CancellationToken cancellationToken = default)
	{
		// var queryParams = 

		await _repository.DeleteAsync<Image>(id, cancellationToken);
	}
}