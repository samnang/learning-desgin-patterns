/* Prototype Pattern:
 * - Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
 * - Co-opt one instance of a class for use as a breeder of all future instances.
 * - The new operator considered harmful.
 */

using System;

namespace Prototype_CS
{
    public class Product : ICloneable
    {
        public int Id { get; set; }
        public string Title { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            // Using shallow copy
            return MemberwiseClone();
        }

        #endregion
    }

    public class Book : Product
    {
        public int NumberOfPages { get; set; }
        public string Author { get; set; }
    }

    public class DVD : Product
    {
        public string Duration { get; set; }
        public string Album { get; set; }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var myBook = new Book {Id = 1, Title = "Design Pattern", NumberOfPages = 123};
            var clonedBook = (Book) myBook.Clone();
            Display(myBook);
            Display(clonedBook);

            var myDvd = new DVD {Id = 2, Title = "Design Pattern", Duration = "60:00"};
            var clonedDvd = (DVD) myDvd.Clone();
            Display(myDvd);
            Display(clonedDvd);

            Console.ReadKey();
        }

        private static void Display(Book book)
        {
            Console.WriteLine("\n=======Book Info=======");
            Console.WriteLine("Id:" + book.Id);
            Console.WriteLine("Title:" + book.Title);
            Console.WriteLine("Number of Pages: " + book.NumberOfPages);
            Console.WriteLine("Author:" + book.Author);
        }

        private static void Display(DVD dvd)
        {
            Console.WriteLine("\n=======DVD Info=======");
            Console.WriteLine("Id:" + dvd.Id);
            Console.WriteLine("Title:" + dvd.Title);
            Console.WriteLine("Duration: " + dvd.Duration);
            Console.WriteLine("Album:" + dvd.Album);
        }
    }
}