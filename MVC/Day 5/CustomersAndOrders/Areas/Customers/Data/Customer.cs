using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersAndOrders.Areas.Customers.Data
{
    public enum Gender
    {
        Male, Female
    }

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 chars")]
        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(enumType: typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:000-0000-0000}")]
        [StringLength(15, ErrorMessage = "Phone number is incorrect")]
        public string Phone { get; set; }
    }
}