using AutoMapper;
using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Queries;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Handlers
{
    public class ConversationWithUserIdQueryHandler: IRequestHandler<ConversationWithUserIdQuery, BaseResponse<ConversationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConversationWithUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<ConversationDto>> Handle(ConversationWithUserIdQuery request, CancellationToken cancellationToken)
        {
            var conversations = await _unitOfWork.ConversationRepository.ConversationByUsersId(request.SenderId, request.ReceiverId);
            return new BaseResponse<ConversationDto>
            {
                Success = true,
                Value = _mapper.Map<ConversationDto>(conversations),
                Message = "conversation fetched succesfully.",
            };

        }
    }
}
