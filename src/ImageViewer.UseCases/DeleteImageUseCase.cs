﻿using AutoMapper;
using ImageViewer.DataAccess.Repository;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;
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

	public async Task<ImageDto?> Invoke(string id, CancellationToken cancellationToken = default)
	{
		// var queryParams = 

		var image = await _repository.DeleteAsync<Image>(id, cancellationToken);

		return _mapper.Map<ImageDto>(image);
	}
}