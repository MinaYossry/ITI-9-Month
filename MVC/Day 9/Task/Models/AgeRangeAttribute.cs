using System.ComponentModel.DataAnnotations;

namespace TraineesDbT.Models
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private int _minAge;
        private int _maxAge;

        public AgeRangeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var dateOfBirth = (DateTime)value;
                var age = DateTime.Today.Year - dateOfBirth.Year;

                if (DateTime.Today < dateOfBirth.AddYears(age))
                {
                    age--;
                }

                if (age < _minAge || age > _maxAge)
                {
                    return false;
                }
            }

            return true;
        }


        //protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        //{
        //    if (value != null)
        //    {
        //        var dateOfBirth = (DateTime)value;
        //        var age = DateTime.Today.Year - dateOfBirth.Year;

        //        if (DateTime.Today < dateOfBirth.AddYears(age))
        //        {
        //            age--;
        //        }

        //        if (age < _minAge || age > _maxAge)
        //        {
        //            return new ValidationResult(ErrorMessage);
        //        }
        //    }

        //    return ValidationResult.Success ?? new ValidationResult(ErrorMessage);
        //}
    }
}
