using AutoMapper;
using SocalMedia.Business.Dtos.CommentDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class CommentMapperProfile : Profile
{
    public CommentMapperProfile()
    {
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
    }
}
