using AutoMapper;
using ParksLookUp.Dtos;
using ParksLookUp.Models;

namespace ParksLookUp.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserDto>();
      CreateMap<UserDto, User>();
    }
  }
}