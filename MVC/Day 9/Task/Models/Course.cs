using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineesDbT.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course topic is required.")]
        [StringLength(50, ErrorMessage = "Course topic cannot be longer than 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Course grade is required.")]
        [Range(0, 100, ErrorMessage = "Course grade must be between 0 and 100.")]
        public int Grade { get; set; }

        [Required]
        [DisplayName("Track")]
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public Track? Track { get; set; }

    }
}
