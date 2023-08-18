using AutoMapper;
using ImageViewer.Api.Model.ApiModels;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.Infrastructure;
using ImageViewer.Infrastructure.Helpers;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class UploadImageUseCase : IUploadImageUseCase
{
	private readonly INHibernateRepository _repository;
	private readonly IMapper _mapper;
	private readonly IFilesHelper _filesHelper;
	private readonly IValidationHelper _validationHelper;

	public UploadImageUseCase(INHibernateRepository repository,
		IMapper mapper,
		IFilesHelper filesHelper,
		IValidationHelper validationHelper)
	{
		_repository = repository;
		_mapper = mapper;
		_filesHelper = filesHelper;
		_validationHelper = validationHelper;
	}

	public async Task<ImageDto> Invoke(UploadImageRequestModel request, CancellationToken cancellationToken)
	{
		var uniqueFileName = Guid.NewGuid() + Path.GetExtension(request.Content.FileName);
		var imagePath = Path.Combine(FileConstants.ImagesRootPath, uniqueFileName);

		var image = new Image
		{
			Name = request.Name,
			Description = request.Description,
			FileName = uniqueFileName,
			Path = imagePath,
		};

		var user = await _repository.GetAsync<User>(1, cancellationToken);
		image.UploadDate = DateTime.Now;
		image.UploadedBy = user;

		await _validationHelper.ValidateAsync(image);
		image = await _repository.SaveAsync<Image>(image, cancellationToken);

		try
		{
			await _filesHelper.CreateFileAsync(imagePath, request.Content, cancellationToken);
		}
		catch (Exception ex)
		{
			//тут откатить, если не создался файл

			//Logger.Error
		}

		//await _repository.FlushAsync(cancellationToken);

		var imageDto = _mapper.Map<ImageDto>(image);
		imageDto.Content = await _filesHelper.ReadFileBytesAsync(imagePath, cancellationToken);

		return imageDto;
	}
}