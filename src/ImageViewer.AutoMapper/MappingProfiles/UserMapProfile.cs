using AutoMapper;
using ImageViewer.Domain.Entities;
using ImageViewer.UseCases.Dto;

namespace ImageViewer.AutoMapper.MappingProfiles;

public class UserMapProfile : Profile
{
	public UserMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<User, UserDto>();
		CreateMap<UserDto, User>();
	}
}