﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D08
{
    public delegate TResult getBookDetail<in T, out TResult>(T item);
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList
        , getBookDetail<Book, string> fPtr)

        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        public static void ProcessBooksBCL(List<Book> bList
        , Func<Book, string> fPtr)

        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
