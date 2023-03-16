using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Model
{
    public enum Gender
    {
        Male, Female
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Can't be more that 50 chars")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(enumType: typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(pattern: "^01[0-2|5]\\d{8}$", ErrorMessage = "Number is not Egyptian phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<Course> Courses { get; set; }    
    }
}
