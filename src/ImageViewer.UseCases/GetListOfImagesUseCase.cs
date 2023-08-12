using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class GetListOfImagesUseCase : IGetListOfImagesUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;

	public GetListOfImagesUseCase(IAsyncRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ImagesDto> Invoke(string? filter, CancellationToken cancellationToken = default)
	{
		// var queryParams = 

		// TODO pass filter
		var images = await _repository.GetAllAsync<Image>(cancellationToken);

		var imagesDto = new ImagesDto
		{
			Images = _mapper.Map<ImageDto[]>(images),
			ImagesCount = images.Count
		};

		return imagesDto;
	}
}