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
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConversationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<BaseResponse<int>> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<Unit>();
            // var validator = new CreateFeedbackValidator();

            //var validatorResult = await validator.ValidateAsync(request.feedbackDto);
            /*
            var resultReponse = new ResultReponse();

            if (!validatorResult.IsValid)
            {
                return resultReponse.ValidationErrorReponse(validatorResult.Errors.Select(q => q.ErrorMessage).ToList());
            }
            */

            var conversation = _mapper.Map<Conversation>(request.conversationDto);
            var noOperations = await _unitOfWork.ConversationRepository.Add(conversation);

            if (noOperations == 0)
            {
                throw new Exception("Unsuccsfull!");
            }
            return new BaseResponse<int>
            {
                Success = true,
                Message = "success",
                Value = conversation.Id,
            };
        }
    }
}
