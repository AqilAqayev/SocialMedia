using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface ICommentService : ICrudService<Comment, CreateCommentDto, UpdateCommentDto, CommentDto>
{
    Task<bool> AddCommentAsync(CreateCommentDto dto);
    Task<bool> ReplyToCommentAsync(CommentReplyDto dto);
}
