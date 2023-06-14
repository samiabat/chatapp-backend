using ChatApp.Application.Common.Dtos.MessageDtos;
using ChatApp.Application.Features.MessageFeature.Commands;
using ChatApp.Application.Features.MessageFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : BaseApiController
    {
        public MessageController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetMessageListQuery { });
            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetMessageDetailQuery { Id = id });
            var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            return getResponse(status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMessageDto messageDto)
        {
            var result = await _mediator.Send(new CreateMessageCommand { messageDto = messageDto });

            var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse(status, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMessageDto messageDto)
        {
            var result = await _mediator.Send(new UpdateMessageCommand { messageDto = messageDto });

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
