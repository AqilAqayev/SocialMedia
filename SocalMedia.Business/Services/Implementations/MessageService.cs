using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.MessageDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class MessageService : CrudService<Message, CreateMessageDto, UpdateMessageDto, MessageDto>, IMessageService
{
    //private readonly IMessageRepository _repository;
    //private readonly IHttpContextAccessor _http;
    //private readonly UserManager<AppUser> _userManager;
    public MessageService(IMessageRepository repository, IMapper mapper) : base(repository, mapper)
    {
       
    }

    //public async Task<Message> CreateMessage(string text,int chatId)
    //{
    //    var chat = await _chatService.GetChatIfExistsAsync(chatId);

    //    var userId =_http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
    //    var user = await _userManager.FindByIdAsync(userId);
    //    if (user is null)
    //         throw new NotFoundException("User not found");

    //    Message message = new()
    //    {
    //        Text = text,
    //        ChatId = chatId,
    //        SenderId = userId,
    //        Chats = chat
    //    };

    //    await _repository.CreateAsync(message);
    //    await _repository.SaveChangesAsync();
    //    return message;
    //}
}
