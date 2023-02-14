using D10;
using L2O___D09;
using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Linq;

void printList(IEnumerable list)
{
    Console.WriteLine("======================================================");
    if (list is not null)
        foreach (var item in list)
            Console.WriteLine(item);
    else
        Console.WriteLine("NA");
}
void printItem<T>(T item)
{
    Console.WriteLine("======================================================");
    Console.WriteLine(item?.ToString() ?? "NA");
    Console.WriteLine("======================================================\n");
}
void printGroup<T1, T2>(IEnumerable<IGrouping<T1, T2>> Group)
{
    Console.WriteLine("======================================================");
    foreach (var CatGroup in Group)
    {
        Console.WriteLine(CatGroup.Key);
        foreach (var Prod in CatGroup)
        {
            Console.WriteLine($"----{Prod}");
        }
    }
    Console.WriteLine("======================================================\n");
}

var ProductList = ListGenerators.ProductList;
var CustomerList = ListGenerators.CustomerList;
string[] NumbersArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
string[] WordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
string[] lineByLine = File.ReadAllLines("dictionary_english.txt");
int[] NumArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// ===================================================================================================================================== //

Console.WriteLine("Find all products that are out of stock.");
var outOfStock = ProductList.Where(p => p.UnitsInStock == 0);
printList(outOfStock);

Console.WriteLine("\nFind all products that are in stock and cost more than 3.00 per unit.");
var costMoreThan3 = ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3.00M);
printList(costMoreThan3);

Console.WriteLine("\nReturns digits whose name is shorter than their value.");
var nameShorterThanValue = NumbersArr.Where((str, i) => str.Length < i);
printList(nameShorterThanValue);

Console.WriteLine("\nGet first Product out of Stock ");
var firstOutOfStock = outOfStock.FirstOrDefault();
printItem(firstOutOfStock);

Console.WriteLine("\nReturn the first product whose Price > 1000, unless there is no match, in which case null is returned.");
var firstPrice1000 = ProductList.Where( p => p.UnitPrice > 1000M ).FirstOrDefault();
printItem(firstPrice1000);

Console.WriteLine("\nRetrieve the second number greater than 5.");
var secondGreaterThan5 = NumArr.Where(num => num > 5).ElementAtOrDefault(1);
printItem(secondGreaterThan5);

Console.WriteLine("\nFind the unique Category names from Product List.");
var uniqueCategory = ProductList.Select(p => p.Category).Distinct();
printList(uniqueCategory);

Console.WriteLine("\nProduce a Sequence containing the unique first letter from both product and customer names.");
var uniqueFirstLetterProdCust = ProductList.Select(p => p.ProductName.ElementAt(0)).Union(CustomerList.Select(c => c.CompanyName.ElementAt(0)));
printList(uniqueFirstLetterProdCust);

Console.WriteLine("\nCreate one sequence that contains the common first letter from both product and customer names.");
var firstCommonLetter = ProductList.Select(p => p.ProductName.ElementAt(0)).Intersect(CustomerList.Select(c => c.CompanyName.ElementAt(0)));
printList(firstCommonLetter);

Console.WriteLine("\nCreate one sequence that contains the first letters of product names that are not also first letters of customer names.");
var firstLettersNotInCustomer = ProductList.Select(p => p.ProductName.ElementAt(0)).Except(CustomerList.Select(c => c.CompanyName.ElementAt(0)));
printList(firstLettersNotInCustomer);

Console.WriteLine("\nCreate one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates.");
var lastThreeChars = CustomerList.Select(c => c.CompanyName[^3..]).Concat(ProductList.Select(p => p.ProductName[^3..]));
printList(lastThreeChars);

Console.WriteLine("\nUses Count to get the number of odd numbers in the array.");
var countOfOdd = NumArr.Count(num => num % 2 == 1);
printItem(countOfOdd);

Console.WriteLine("\nReturn a list of customers and how many orders each has.");
var listOfCustAndOrders = CustomerList.Select(c => new { c.CompanyName, OrderCount = c.Orders.Length });
printList(listOfCustAndOrders);

Console.WriteLine("\nReturn a list of categories and how many products each has.");
var listOfCategoryAndProducts = from p in ProductList
                                group p by p.Category into grouping
                                select new { Category = grouping.Key, ProductCount = grouping.Count() };
printList(listOfCategoryAndProducts);

Console.WriteLine("\nGet the total of the numbers in an array.");
var sumOfNumber = NumArr.Sum();
printItem(sumOfNumber);

Console.WriteLine("\nGet the total number of characters of all words in dictionary_english.txt");
var countLineByLine = lineByLine.Sum(line => line.Length);
printItem(countLineByLine);

Console.WriteLine("\nGet the total units in stock for each product category.");
var totalStockPerCategory = from p in ProductList
                            group p.UnitsInStock by p.Category into grouping
                            select new { Category = grouping.Key, UnitsInStock = grouping.Sum() };

var totalStockPerCategory2 = ProductList.GroupBy(item => item.Category)
                                           .Select(group => new { Category = group.Key, UnitsInStock = group.Sum(count => count.UnitsInStock)});
printList(totalStockPerCategory);
printList(totalStockPerCategory2);

Console.WriteLine("\nGet the length of the shortest word in dictionary_english.txt");
var lengthOfShortestWord = lineByLine.Min(line => line.Length);
printItem(lengthOfShortestWord);

Console.WriteLine("\nGet the cheapest price among each category's products");
var cheapestPriceInEachCategory = ProductList.GroupBy(p => p.Category, p => p.UnitPrice, (Category, Price) => new { Category, Price = Price.Min() });
printList(cheapestPriceInEachCategory);

Console.WriteLine("\n Get the products with the cheapest price in each category (Use Let)");
var productsWithTheCheapestPrice = ProductList.GroupBy(p => p.Category, p => p, (Category, Product) => new { Category, Product = Product.MinBy(p => p.UnitPrice) });
printList(productsWithTheCheapestPrice);

// With Let
var productsWithTheCheapestPrice2 = from p in ProductList
                                    group p by p.Category into grouping
                                    let minValues = grouping.Min(p => p.UnitPrice)
                                    select grouping.Where(p => p.UnitPrice == minValues);

foreach (var item in productsWithTheCheapestPrice2)
{
    foreach (var Product in item)
    {
        Console.WriteLine(Product);
    }
}

Console.WriteLine("\nGet the length of the longest word in dictionary_english.txt");
var lengthOfLongestWord =lineByLine.Max(line => line.Length);
printItem(lengthOfLongestWord);

Console.WriteLine("\nGet the most expensive price among each category's products.");
var maxPriceInEachCategory = ProductList.GroupBy(p => p.Category, p => p.UnitPrice, (Category, Price) => new { Category, Price = Price.Max() });
printList(maxPriceInEachCategory);

Console.WriteLine("\nGet the most expensive price among each category's products.");
var expensiveProductInCategory = ProductList.GroupBy(p => p.Category, p => p, (Category, Product) => new { Category, Product = Product.MaxBy(p => p.UnitPrice) });
printList(expensiveProductInCategory);

Console.WriteLine("\n Get the average length of the words in dictionary_english.txt");
var averageLength = lineByLine.Average(word => word.Length);
printItem(averageLength);

Console.WriteLine("\nGet the average price of each category's products.");
var averagePrice = ProductList.Average(p => p.UnitPrice);
printItem(averagePrice);

Console.WriteLine("\nSort a list of products by name");
var sortedList = ProductList.OrderBy(p => p.ProductName);
printList(sortedList);

Console.WriteLine("\nUses a custom comparer to do a case-insensitive sort of the words in an array.");
var sortedArr = WordsArr.OrderBy(str => str, new CustomStringComparer());
// OrderBy is already case-insensitive, so this gives the same results
// var sortedArr = WordsArr.OrderBy(str => str);
// or this
// var sortedArr = WordsArr.OrderBy(str => str, StringComparer.OrdinalIgnoreCase);
printList(sortedArr);

Console.WriteLine("\nSort a list of products by units in stock from highest to lowest.");
var sortedListHighToLow = ProductList.OrderByDescending(p => p.UnitsInStock);
printList(sortedListHighToLow);

Console.WriteLine("\n Sort a list of digits, first by length of their name, and then alphabetically by the name itself.");
var sortedDigits = NumbersArr.OrderBy(str => str.Length).ThenBy(str => str);
printList(sortedDigits);

Console.WriteLine("\n Sort first by word length and then by a case-insensitive sort of the words in an array.");
var sortedWords = WordsArr.OrderBy(str => str.Length).ThenBy(str => str);
printList(sortedWords);

Console.WriteLine("\nSort a list of products, first by category, and then by unit price, from highest to lowest.");
var sortedList2 = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
printList(sortedList2);

Console.WriteLine("\nSort first by word length and then by a case-insensitive descending sort of the words in an array.");
var sortedWordsArr = WordsArr.OrderBy(str => str.Length).ThenByDescending(str => str);
printList(sortedWordsArr);

Console.WriteLine("\nCreate a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.");
var secondLetterArr = NumbersArr.Where(str => str.ElementAt(1) == 'i').Reverse();
printList(secondLetterArr);

Console.WriteLine("\nGet the first 3 orders from customers in Germany");
var top3FromWashingtom = CustomerList.Where(c => c.Country == "Germany").Select(c => new { c, c.Orders }).Take(3);
printList(top3FromWashingtom);

Console.WriteLine("\nGet all but the first 2 orders from customers in Germany.");
var allBut2FromWashingtom = CustomerList.Where(c => c.Country == "Germany").Select(c => new { c, c.Orders }).Take(2..);
printList(allBut2FromWashingtom);

Console.WriteLine("\nReturn elements starting from the beginning of the array until a number is hit that is less than its position in the array.");
var numbers = NumArr.TakeWhile((num, index) => num >= index);
printList(numbers);

Console.WriteLine("\nGet the elements of the array starting from the first element divisible by 3.");
var startingFromDiv3 = NumArr.SkipWhile((num) => num % 3 != 0);
printList(startingFromDiv3);

Console.WriteLine("\nGet the elements of the array starting from the first element divisible by 3.");
var starting = NumArr.SkipWhile((num, index) => num >= index);
printList(starting);

Console.WriteLine("\nReturn a sequence of just the names of a list of products.");
var justNames = ProductList.Select(p => p.ProductName);
printList(justNames);

Console.WriteLine("\nProduce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).");
var upperAndLower = WordsArr.Select(word => new {Upper = word.ToUpper(), Lower = word.ToLower()});
printList(upperAndLower);

Console.WriteLine("\nProduce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.");
var someProperties = ProductList.Select(p => new { Price = p.UnitPrice, p.ProductID });
printList(someProperties);

Console.WriteLine("\nDetermine if the value of ints in an array match their position in the array.");
var numberMatch = NumArr.Select((num, index) => num == index);
printList(numberMatch);

Console.WriteLine("\nReturns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.");
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };
var numbersPairs = from a in numbersA
                   from b in numbersB
                   where a < b
                   select new { a, b };
printList(numbersPairs);

Console.WriteLine("\nSelect all orders where the order total is less than 500.00.");
var ordersTotal500 = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500.0m);
printList(ordersTotal500);


Console.WriteLine("\nSelect all orders where the order was made in 1998 or later.");
var orderAfter1998 = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
printList(orderAfter1998);

Console.WriteLine("\nDetermine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.");
var containEI = lineByLine.Where(word => word.Contains("ei"));
printList(containEI);

Console.WriteLine("\nReturn a grouped a list of products only for categories that have at least one product that is out of stock.");
var categoriesOutOfStock = ProductList.GroupBy(p => p.Category).Where(group => group.Any(prod => prod.UnitsInStock == 0));
printGroup(categoriesOutOfStock);

Console.WriteLine("\nReturn a grouped a list of products only for categories that have all of their products in stock.");
var categoriesAllInStock = ProductList.GroupBy(p => p.Category).Where(group => group.All(prod => prod.UnitsInStock != 0));
printGroup(categoriesAllInStock);

Console.WriteLine("\nUse group by to partition a list of numbers by their remainder when divided by 5.");
var listOfNumber = Enumerable.Range(0, 15);
var groupByRemainder = listOfNumber.GroupBy((num => num % 5));
printGroup(groupByRemainder);

Console.WriteLine("\nUses group by to partition a list of words by their first letter.");
var groupByLetter = lineByLine.GroupBy(word => word.FirstOrDefault());
printGroup(groupByLetter);

Console.WriteLine("\nUse Group By with a custom comparer that matches words that are consists of the same Characters Together.");
string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
var groupBySameLetters = Arr.GroupBy(str => str, new CustomSameLettersComparer());
printGroup(groupBySameLetters);