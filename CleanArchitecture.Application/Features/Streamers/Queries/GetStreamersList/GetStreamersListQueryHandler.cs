using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Queries.GetStreamersList
{
    public class GetStreamersListQueryHandler : IRequestHandler<GetStreamersListQuery, List<Streamer>>
    {
        private readonly IAsyncRepository<Streamer> _streamersRepository;
        private readonly IMapper _mapper;
        public GetStreamersListQueryHandler(IAsyncRepository<Streamer> streamersRepository, IMapper mapper)
        {
            _streamersRepository = streamersRepository;
            _mapper = mapper;
        }

        public async Task<List<Streamer>> Handle(GetStreamersListQuery request, CancellationToken cancellationToken)
        {
            var streamerList = await _streamersRepository.GetAllAsync();

            return _mapper.Map<List<Streamer>>(streamerList);
        }
    }
}
