using AutoMapper;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;

namespace ImageViewer.AutoMapper.MappingProfiles;

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