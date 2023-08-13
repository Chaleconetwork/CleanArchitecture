using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class StreamerRepository: RepositoryBase<Streamer>, IStreamerRepository
    {
        
        public StreamerRepository(Context context): base(context)
        {
            
        }
    }
}
