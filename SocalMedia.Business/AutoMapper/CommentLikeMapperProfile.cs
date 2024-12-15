using AutoMapper;
using SocalMedia.Business.Dtos.CommentLikeDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.AutoMapper;

public class CommentLikeMapperProfile : Profile
{
    public CommentLikeMapperProfile()
    {
        CreateMap<CommentLike, CommentLikeDto>().ReverseMap();
        CreateMap<CommentLike, CreateCommentLikeDto>().ReverseMap();
        CreateMap<CommentLike, UpdateCommentLikeDto>().ReverseMap();
    }
}
