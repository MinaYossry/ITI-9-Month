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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<string?> numbers = new();
        private StringBuilder currentNumber = new();
        private bool dot = false;
        private bool op = false;


        private void Update_Field(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var value = btn.Content.ToString();
                switch (value)
                {
                    case "=":
                        numbers.Add(currentNumber.ToString());
                        double result = Solve();
                        ClearState();
                        EQ.Text = result.ToString();
                        currentNumber.Append(result);
                        break;
                    case ".":
                        if (!dot)
                        {
                            EQ.Text += value;
                            currentNumber.Append(value);
                            dot = true;
                        }
                        break;
                    case "-":
                        if (!op)
                        {
                            HandleOperator(value);
                            currentNumber.Append('-');
                        }
                        break;
                    case "+":
                    case "*":
                    case "/":
                        if (!op)
                        {
                            HandleOperator(value);
                        }
                        break;
                    default:
                        currentNumber.Append(value);
                        EQ.Text += value;
                        op = false;
                        break;
                }
            }
        }

        private void HandleOperator(string value)
        {
            numbers.Add(currentNumber.ToString());
            currentNumber.Clear();
            numbers.Add(value);
            EQ.Text += value;
            dot = false;
            op = true;
        }

        private void ClearState()
        {
            numbers.Clear();
            currentNumber.Clear();
            dot = false;
            op = false;
        }

        private double Solve()
        {
            double result = 0;
            int i = 0;
            while (i < numbers?.Count)
            {
                double number;
                if (double.TryParse(numbers[i], out number))
                {
                    if (i + 1 < numbers.Count && (numbers[i + 1] == "*" || numbers[i + 1] == "/"))
                    {
                        bool isMulti = numbers[i + 1] == "*";
                        double nextNumber = double.Parse(numbers?[i + 2] ?? "0");
                        number = isMulti ? number * nextNumber : number / nextNumber;
                        i += 2;
                    }
                    result += number;
                }
                i++;
            }
            return result;
        }
    }
}
