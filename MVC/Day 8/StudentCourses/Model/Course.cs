using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCourses.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Must Enter a Topic")]
        [StringLength(50, ErrorMessage = "Max is 50 chars")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Must enter a Grade")]
        public int CourseGrade { get; set; }

        [Required(ErrorMessage = "Course must be assigned to student")]
        [DisplayName("Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
