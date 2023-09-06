using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Queries.GetStreamersList
{
    public class GetStreamersListQuery: IRequest<List<Streamer>>
    {
        public GetStreamersListQuery()
        {
            
        }
    }
}
