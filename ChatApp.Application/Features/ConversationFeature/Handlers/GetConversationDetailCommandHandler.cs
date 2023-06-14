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
    public class GetConversationDetailCommandHandler: IRequestHandler<GetConversationDetailQuery, BaseResponse<ConversationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetConversationDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<ConversationDto>> Handle(GetConversationDetailQuery request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.Get(request.Id);

            if (conversation == null)
            {
                throw new Exception($"Feedback with ID {request.Id} does not exist");
            }
            return new BaseResponse<ConversationDto>{
                Success = true,
                Value = _mapper.Map<ConversationDto>(conversation),
                Message = "feedback fetched succesfully.",
            };
        }
    }
}
