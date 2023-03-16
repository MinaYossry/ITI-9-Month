using CustomersAndOrders.Areas.Customers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomersAndOrders.Areas.Orders.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [ItemCount(0)]
        public int ItemCount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        [Required]
        [DisplayName("Customer")]
        public int CustomerId { get; set; } // foreign key property

        [ForeignKey("CustomerId")] // configure the relationship
        public Customer Customer { get; set; }
    }
}