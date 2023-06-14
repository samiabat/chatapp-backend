using AutoMapper;
using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Common.Dtos.MessageDto;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Queries;
using ChatApp.Application.Features.MessageFeature.Queries;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.MessageFeature.Handlers
{
    public class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, BaseResponse<List<MessageDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<MessageDto>>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var messages = await _unitOfWork.MessageRepository.GetAll();
            return new BaseResponse<List<MessageDto>>
            {
                Success = true,
                Value = _mapper.Map<List<MessageDto>>(messages),
                Message = "messages fetched succesfully.",
            };

        }
    }
}