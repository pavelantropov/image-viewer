using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;

using AutoMapper;

namespace ImageViewer.Infrastructure.MappingProfiles;

public class ImageMapProfile : Profile
{
	public ImageMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<Image, ImageDto>();
		CreateMap<ImageDto, Image>();
	}
}