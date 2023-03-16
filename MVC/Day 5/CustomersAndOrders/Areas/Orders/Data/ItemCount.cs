using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomersAndOrders.Areas.Orders.Data
{
    public class ItemCount : ValidationAttribute
    {
        int Count { get; set; } 

        public ItemCount(int count)
        {
            Count = count;
        }

        public override bool IsValid(object value)
        {
            if (value is null)
                return false;
            
            if (value is int)
            {
                if ((int)value > Count)
                    return true;
                else
                {
                    ErrorMessage = $"Item Count can't be less than {Count}";
                    return false;
                }
            }
            return false;
        }
    }
}