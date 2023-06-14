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
    public class GetConversationListQueryHandler: IRequestHandler<GetConversationListQuery, BaseResponse<List<ConversationDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetConversationListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<ConversationDto>>> Handle(GetConversationListQuery request, CancellationToken cancellationToken)
        {
            var conversations = await _unitOfWork.ConversationRepository.GetAll();
            return new BaseResponse<List<ConversationDto>>
            {
                Success = true,
                Value = _mapper.Map<List<ConversationDto>>(conversations),
                Message = "feedback fetched succesfully.",
            };
            
        }
    }
}
