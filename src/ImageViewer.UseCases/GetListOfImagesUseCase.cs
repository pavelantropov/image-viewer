using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.Infrastructure.Helpers;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class GetListOfImagesUseCase : IGetListOfImagesUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;
	private readonly IFilesHelper _filesHelper;
	private readonly IValidationHelper _validationHelper;

	public GetListOfImagesUseCase(IAsyncRepository repository,
		IMapper mapper,
		IFilesHelper filesHelper,
		IValidationHelper validationHelper)
	{
		_repository = repository;
		_mapper = mapper;
		_filesHelper = filesHelper;
		_validationHelper = validationHelper;
	}

	public async Task<ImagesDto> Invoke(string filter, CancellationToken cancellationToken = default)
	{
		// var queryParams = 

		// TODO pass filter
		var images = await _repository.GetAllAsync<Image>(cancellationToken);

		var dtos = new List<ImageDto>();

		foreach (var image in images)
		{
			await _validationHelper.ValidateAsync(image);
			var dto = _mapper.Map<ImageDto>(image);
			dto.Content = await _filesHelper.ReadFileBytesAsync(image.Path, cancellationToken);

			dtos.Add(dto);
		}

		var imagesDto = new ImagesDto
		{
			Images = dtos,
			ImagesCount = dtos.Count
		};

		return imagesDto;
	}
}