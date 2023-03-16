using Microsoft.EntityFrameworkCore;
using TraineesDbT.Models;

namespace TraineesDbT.DataAccessRepos
{
    public class TraineeRepoService : EfCoreRepo<Trainee>
    {
        public TraineeRepoService(TraineesDbContext traineesDbContext) : base(traineesDbContext)
        {
            
        }
    }
}
