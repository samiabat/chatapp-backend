using AutoMapper;
using ChatApp.Application.Contracts.Persistence;
using ChatApp.Application.Features.ConversationFeature.Commands;
using ChatApp.Application.Features.MessageFeature.Commands;
using ChatApp.Application.Responses;
using ChatApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.MessageFeature.Handlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<BaseResponse<int>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // var validator = new CreateFeedbackValidator();

            //var validatorResult = await validator.ValidateAsync(request.feedbackDto);
            /*
            var resultReponse = new ResultReponse();

            if (!validatorResult.IsValid)
            {
                return resultReponse.ValidationErrorReponse(validatorResult.Errors.Select(q => q.ErrorMessage).ToList());
            }
            */

            var message = _mapper.Map<Message>(request.messageDto);
            var noOperations = await _unitOfWork.MessageRepository.Add(message);

            if (noOperations == 0)
            {
                throw new Exception("Unsuccsfull!");
            }
            return new BaseResponse<int>
            {
                Success = true,
                Message = "success",
                Value = message.Id,
            };
        }
    }
}
