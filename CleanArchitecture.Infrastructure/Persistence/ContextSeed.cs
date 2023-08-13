using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class ContextSeed
    {
        public static async Task SeedAsync(Context context, ILogger<Context> logger)
        {
            if (!context.Streamers!.Any()) 
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Registros insertados");
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "Chaleco", Nombre = "Uwu", Url = "http://www.uwu.com"},
                new Streamer {CreatedBy = "Chaleco", Nombre = "Buuf", Url = "http://www.buuf.com"}
            };
        }
    }
}
