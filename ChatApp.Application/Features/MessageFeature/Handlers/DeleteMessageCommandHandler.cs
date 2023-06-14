using AutoMapper;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Commands;
using ChatApp.Application.Features.MessageFeature.Commands;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.MessageFeature.Handlers
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMessageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        public async Task<BaseResponse<int>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _unitOfWork.MessageRepository.Get(request.Id);

            if (message == null)
                throw new Exception("Resource Not Found");


            if (await _unitOfWork.MessageRepository.Delete(message) == 0)
                throw new Exception("Database Error: Unable To Save");

            return new BaseResponse<int>
            {
                Success = true,
                Message = "Deletion Succeeded",
                Value = message.Id,
            };

        }
    }
}
