using AutoMapper;
using Forum.Application.DTOs;
using Forum.Application.Identity;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application
{
    public class MappingInitializer
    {
        public static IMapper Initialize()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<Topic, TopicForCreatingDTO>().ReverseMap();
                config.CreateMap<Topic, TopicForUpdatingDTO>().ReverseMap();
                config.CreateMap<Topic, TopicForGettingDTO>()
                .ForMember(destination => destination.NumberOfComments, options => options.MapFrom(source => source.Comments!.Count))
                .ReverseMap();

                config.CreateMap<Comment, CommentForCreatingDTO>().ReverseMap();
                config.CreateMap<Comment, CommentForUpdatingDTO>().ReverseMap();
                config.CreateMap<Comment, CommentForGettingDTO>().ReverseMap();

                config.CreateMap<UserDto, IdentityUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDTO, IdentityUser>()
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.UserName))
                .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.UserName.ToUpper()))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.PhoneNumber, options => options.MapFrom(source => source.PhoneNumber));
            });
            return configuration.CreateMapper();
        }
    }
}
