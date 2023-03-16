using TraineesDbT.Models;

namespace TraineesDbT.DataAccessRepos
{
    public class TrackRepoService : EfCoreRepo<Track>
    {
        public TrackRepoService(TraineesDbContext traineesDbContext) : base(traineesDbContext)
        {
            
        }
    }
}
