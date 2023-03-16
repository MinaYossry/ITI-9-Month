using System.ComponentModel.DataAnnotations;

namespace TraineesDbT.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Track name is required.")]
        [StringLength(50, ErrorMessage = "Track name cannot be longer than 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description name is required.")]
        [StringLength(200, ErrorMessage = "Track description cannot be longer than 200 characters.")]
        public required string Description { get; set; }

        public ICollection<Course>? Courses { get; set; }

        public ICollection<Trainee>? Trainees { get; set; }
    }
}
