using TraineesDbT.Models;

namespace TraineesDbT.DataAccessRepos
{
    public class CourseRepoService : EfCoreRepo<Course>
    {
        public CourseRepoService(TraineesDbContext traineesDbContext) : base(traineesDbContext)
        {
            
        }
    }
}
