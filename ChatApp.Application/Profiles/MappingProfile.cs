using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChatApp.Application.Common.Dtos.ConversationDto;
using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Common.Dtos.MessageDto;
using ChatApp.Application.Common.Dtos.MessageDtos;
using ChatApp.Application.Common.Dtos.Security;
using ChatApp.Domain.AuthModel;
using ChatApp.Domain.Models;

namespace ChatApp.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            #endregion
            #region
            CreateMap<Conversation, CreateConversationDto>().ReverseMap();
            CreateMap<Conversation, UpdateConversationDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            #endregion

            #region 
            CreateMap<ApplicationRole, RoleDto>().ReverseMap();
            CreateMap<ApplicationUser, UserCreationDto>().ReverseMap();
            CreateMap<ApplicationUser, UserCreationDto>().ReverseMap();
            CreateMap<ApplicationUser, UserUpdatingDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, AdminUserDto>().ReverseMap();
             CreateMap<ApplicationUser, AdminCreationDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDtailDto>().ReverseMap();
            }
            #endregion
    }
}
