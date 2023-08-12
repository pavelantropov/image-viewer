using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class PostImageUseCase : IPostImageUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;

	public PostImageUseCase(IAsyncRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ImageDto?> Invoke(ImageDto imageDto, CancellationToken cancellationToken)
	{
		// var queryParams = 

		var image = await _repository.SaveAsync<Image>(_mapper.Map<Image>(imageDto), cancellationToken);

		return _mapper.Map<ImageDto>(image);
	}
}