using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CarList
    {
        public static List<Car> List { get; set; } = new List<Car>()
        {
            new Car() {Id = 1, Color = "Red", Manufacture = "BMW", Model = "X6"},
            new Car() {Id = 2, Color = "Black", Manufacture = "BMW", Model = "X5"},
            new Car() {Id = 3, Color = "Blue", Manufacture = "BMW", Model = "X4"},
            new Car() {Id = 4, Color = "Green", Manufacture = "BMW", Model = "X3"},
            new Car() {Id = 5, Color = "Gray", Manufacture = "BMW", Model = "X2"},
        };
    }
}
