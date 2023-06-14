using AutoMapper;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Commands;
using ChatApp.Application.Responses;
using ChatApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.ConversationFeature.Handlers
{
    public class UpdateConversationCommandHandler: IRequestHandler<UpdateConversationCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateConversationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<int>> Handle(UpdateConversationCommand request, CancellationToken cancellationToken)
        {
            /*
            var validator = new UpdateFeedbackValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request.feedbackDto);
            var resultResponse = new ResultReponse();

            if (!validatorResult.IsValid)
            {
                return resultResponse.ValidationErrorReponse(validatorResult.Errors.Select(q => q.ErrorMessage).ToList());
            }
            */

            var conversation = _mapper.Map<Conversation>(request.conversationDto);
            var noOperations = await _unitOfWork.ConversationRepository.Update(conversation);
            if (noOperations == 0)
            {
                throw new Exception("Unsuccesful!");
            }
            return new BaseResponse<int> { 
                Success = true,
                Message = "success",
                Value = conversation.Id,
            };
        }
    }
}
