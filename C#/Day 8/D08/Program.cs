
using D08;

string[] Authors = { "A1", "A2" };

List<Book> bList = new()
{
    new("1", "Book1", Authors, new(2005,5,20), (decimal)5.5),
    new("2", "Book2", Authors, new(2006,6,25), (decimal)6.5),
    new("3", "Book3", Authors, new(2007,7,28), (decimal)7.5),
    new("4", "Book4", Authors, new(2008,8,27), (decimal)8.5),
    new("5", "Book4", Authors, new(2009,9,29), (decimal)9.5),
};


// User Defined Delegates
Console.WriteLine("User Defined Delegates");
Console.WriteLine("========================================");

LibraryEngine.ProcessBooks(bList, BookFunctions.GetTitle);
LibraryEngine.ProcessBooks(bList, BookFunctions.GetAuthors);
LibraryEngine.ProcessBooks(bList, BookFunctions.GetPrice);

Console.WriteLine("========================================\n");

// BCL Delegates
Console.WriteLine("BCL Delegates");
Console.WriteLine("========================================");

LibraryEngine.ProcessBooksBCL(bList, BookFunctions.GetTitle);
LibraryEngine.ProcessBooksBCL(bList, BookFunctions.GetAuthors);
LibraryEngine.ProcessBooksBCL(bList, BookFunctions.GetPrice);

Console.WriteLine("========================================\n");

// Anonymous Method
Console.WriteLine("Anonymous Method");
Console.WriteLine("========================================");

Func<Book, string> fptr = delegate (Book book) { return book.ISBN; };

LibraryEngine.ProcessBooksBCL(bList, fptr);
Console.WriteLine("========================================\n");

// Lambda Expression
Console.WriteLine("Lambda Expression");
Console.WriteLine("========================================");

LibraryEngine.ProcessBooksBCL(bList, book => $"{book.PublicationDate}");

Console.WriteLine("========================================\n");