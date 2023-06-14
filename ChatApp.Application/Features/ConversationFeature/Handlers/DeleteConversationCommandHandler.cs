using AutoMapper;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Commands;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Handlers
{
    public class DeleteConversationCommandHandler: IRequestHandler<DeleteConversationCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteConversationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        public async Task<BaseResponse<int>> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.Get(request.Id);

            if (conversation == null)
                throw new Exception("Resource Not Found");


            if (await _unitOfWork.ConversationRepository.Delete(conversation) == 0)
                throw new Exception("Database Error: Unable To Save");

            return new BaseResponse<int> { 
                Success = true,
                Message = "Deletion Succeeded",
                Value = conversation.Id,
             };

        }
    }
}
