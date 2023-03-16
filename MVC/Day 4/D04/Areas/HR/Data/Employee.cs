using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace D04.Areas.HR.Data
{
    public enum Gender
    {
        Male,Female
    }

    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "You must enter employee ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter employee Name")]
        [MaxLength(50, ErrorMessage = "Name length shouldn't exceed 50 letters")]
        [MinLength(2, ErrorMessage = "Name length can't be 2 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EnumDataType(enumType: typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [Range(4000.0, 4000000.0, ErrorMessage = "Salary must be within range (4000, 4000000)")]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}