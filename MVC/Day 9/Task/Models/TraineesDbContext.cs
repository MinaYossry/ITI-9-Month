using Microsoft.EntityFrameworkCore;

namespace TraineesDbT.Models
{
    public class TraineesDbContext : DbContext
    {
        public TraineesDbContext(DbContextOptions<TraineesDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>().Navigation(T => T.Track).AutoInclude();

            modelBuilder.Entity<Course>().Navigation(T => T.Track).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Trainee>  Trainees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    }
}
