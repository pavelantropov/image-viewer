using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class GetImageUseCase : IGetImageUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;

	public GetImageUseCase(IAsyncRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ImageDto?> Invoke(int id, CancellationToken cancellationToken = default)
	{
		// var queryParams = 

		var image = await _repository.GetAsync<Image>(id, cancellationToken);

		return _mapper.Map<ImageDto>(image);
	}
}