using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTask.Models
{
    public class CarList
    {
        public static List<Car> List { get; set; } = new List<Car>()
        {
            new Car() {Num = 1, Color = "Red", Manufacture = "BMW", Model = "X6"},
            new Car() {Num = 2, Color = "Black", Manufacture = "BMW", Model = "X5"},
            new Car() {Num = 3, Color = "Blue", Manufacture = "BMW", Model = "X4"},
            new Car() {Num = 4, Color = "Green", Manufacture = "BMW", Model = "X3"},
            new Car() {Num = 5, Color = "Gray", Manufacture = "BMW", Model = "X2"},
        };
    }
}