using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new()
        {
            new Student() {ID = 1, Age=24, Name="Name1", Grade=80, Image="/img.jpg"},
            new Student() {ID = 2, Age=25, Name="Name2", Grade=82, Image="/img.jpg"},
            new Student() {ID = 3, Age=26, Name="Name3", Grade=83, Image="/img.jpg"},
            new Student() {ID = 4, Age=27, Name="Name4", Grade=84, Image="/img.jpg"},
        };
        public MainWindow()
        {
            InitializeComponent();
            lst.ItemsSource = students;
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public int Grade { get; set; }
        public override string ToString()
        {
            return $"{ID}: {Name}";
        }
    }
}
