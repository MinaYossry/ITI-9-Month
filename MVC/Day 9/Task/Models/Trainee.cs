using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineesDbT.Models
{
    public enum Gender { Male, Female }

    public class Trainee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Trainee name is required.")]
        [StringLength(50, ErrorMessage = "Trainee name cannot be longer than 50 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Trainee gender is required.")]
        [EnumDataType(enumType: typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Trainee email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Trainee mobile number is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:\+20|0)?1[0125]\d{8}$", ErrorMessage = "Invalid mobile number format.")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Trainee birthdate is required.")]
        [DataType(DataType.Date)]
        [AgeRange(18, 60, ErrorMessage = "Trainee age must be between 18 and 60.")]
        public DateTime Birthdate { get; set; }

        [Required]
        [DisplayName("Track")]
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public Track? Track { get; set; }


        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType())
                return false;

            Trainee? T = obj as Trainee;
            if (T is null) return false;
            else
                return Id == T.Id &&
                      Name == T.Name &&
                      Gender == T.Gender &&
                      Email == T.Email &&
                      Phone == T.Phone &&
                      Birthdate == T.Birthdate &&
                      TrackId == T.TrackId &&
                      Track == T.Track;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
