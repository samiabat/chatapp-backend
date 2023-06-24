using ChatApp.Application.Common.Dtos.ConversationDto;
using ChatApp.Application.Common.Dtos.ConversationDtos;
using ChatApp.Application.Features.ConversationFeature.Commands;
using ChatApp.Application.Features.ConversationFeature.Queries;
using ChatApp.Application.Features.MessageFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : BaseApiController
    {
        public ConversationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetConversationListQuery { });
            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetConversationDetailQuery { Id = id });
            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }


        [HttpGet("byUserId")]
        public async Task<IActionResult> Get([FromQuery] string SenderId, string ReceiverId)
        {
            var result = await _mediator.Send(new ConversationWithUserIdQuery { SenderId = SenderId, ReceiverId=ReceiverId });
            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateConversationDto conversationDto)
        {
            var result = await _mediator.Send(new CreateConversationCommand { conversationDto = conversationDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse(status, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateConversationDto conversationDto)
        {
            var result = await _mediator.Send(new UpdateConversationCommand { conversationDto = conversationDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse(status, result);
        }

        [HttpDelete]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _mediator.Send(new DeleteMessageCommand { Id = id });
            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse(status, result);
        }
    }
}
