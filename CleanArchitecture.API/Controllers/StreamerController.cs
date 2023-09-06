using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Streamers.Queries.GetStreamersList;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetStreamers")]
        [Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<Streamer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Streamer>>> GetStreamers()
        {
            var query = new GetStreamersListQuery();
            var streamers = await _mediator.Send(query);

            return Ok(streamers);
        }

        [HttpPost(Name = "CreateStreamer")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody]CreateStreamerCommand  command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateStreamaer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStreamaer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            var command = new DeleteStreamerCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
