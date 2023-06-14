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
    public class GetMessageDetailQueryHandler : IRequestHandler<GetMessageDetailQuery, BaseResponse<MessageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMessageDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<MessageDto>> Handle(GetMessageDetailQuery request, CancellationToken cancellationToken)
        {
            var message = await _unitOfWork.MessageRepository.Get(request.Id);

            if (message == null)
            {
                throw new Exception($"message with ID {request.Id} does not exist");
            }
            return new BaseResponse<MessageDto>
            {
                Success = true,
                Value = _mapper.Map<MessageDto>(message),
                Message = "message fetched succesfully.",
            };
        }
    }
}
