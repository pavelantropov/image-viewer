using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.ApiModels;
using ImageViewer.UseCases.Dto;
using ImageViewer.UseCases.Interfaces;

namespace ImageViewer.UseCases;

public class UploadImageUseCase : IUploadImageUseCase
{
	private readonly INHibernateRepository _repository;
	private readonly IMapper _mapper;

	public UploadImageUseCase(INHibernateRepository repository,
		IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<ImageDto> Invoke(UploadImageRequestModel request, CancellationToken cancellationToken)
	{
		var uniqueFileName = Guid.NewGuid() + Path.GetExtension(request.Content.FileName);
		var imagePath = Path.Combine(@"./images/", uniqueFileName);

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

		image = await _repository.SaveAsync<Image>(image, cancellationToken);

		try
		{
			await using var stream = new FileStream(imagePath, FileMode.Create);
			await request.Content.CopyToAsync(stream, cancellationToken);
		}
		catch (Exception ex)
		{
			//тут откатить, если не создался файл

			//Logger.Error
		}

		await _repository.FlushAsync(cancellationToken);

		return _mapper.Map<ImageDto>(image);
	}
}