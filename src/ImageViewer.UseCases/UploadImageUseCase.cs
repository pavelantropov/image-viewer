using AutoMapper;
using ImageViewer.Api.Model.ApiModels;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.Domain.Factories;
using ImageViewer.Infrastructure;
using ImageViewer.Infrastructure.Helpers;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;
using NLog;

namespace ImageViewer.UseCases;

public class UploadImageUseCase : IUploadImageUseCase
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private readonly INHibernateRepository _repository;
	private readonly IMapper _mapper;
	private readonly IFilesHelper _filesHelper;
	private readonly IImageFactory _imageFactory;

	public UploadImageUseCase(INHibernateRepository repository,
		IMapper mapper,
		IFilesHelper filesHelper,
		IImageFactory imageFactory)
	{
		_repository = repository;
		_mapper = mapper;
		_filesHelper = filesHelper;
		_imageFactory = imageFactory;
	}

	public async Task<ImageDto> Invoke(UploadImageRequestModel request, CancellationToken cancellationToken)
	{
		// TODO for now assigning all images to the only user in the DB
		var user = await _repository.GetAsync<User>(1, cancellationToken);
		var extension = Path.GetExtension(request.Content.FileName);

		var image = await _imageFactory.CreateAsync(request.Name, request.Description, user, extension);

		try
		{
			await _filesHelper.CreateFileAsync(image.Path, request.Content, cancellationToken);
			image = await _repository.SaveAsync<Image>(image, cancellationToken);
		}
		catch (Exception ex)
		{
			Logger.Error(ex);
			throw;
		}

		var imageDto = _mapper.Map<ImageDto>(image);
		imageDto.Content = await _filesHelper.ReadFileBytesAsync(image.Path, cancellationToken);

		return imageDto;
	}
}