using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.ApiModels;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class UploadImageUseCase : IUploadImageUseCase
{
	private readonly IAsyncRepository _repository;
	private readonly IMapper _mapper;

	public UploadImageUseCase(IAsyncRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ImageDto?> Invoke(UploadImageRequestModel request, CancellationToken cancellationToken)
	{
		//?TODO use transaction


		//TODO
		var image = await _repository.SaveAsync<Image>(_mapper.Map<Image>(imageDto), cancellationToken);

		return _mapper.Map<ImageDto>(image);
	}
}