using System;
using bookAppBackend;

namespace bookAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookTitle = "Fellowship of the Rings";
            string bookAuthor = "J.R.R. Tokien";
            string pubYear = "1954";

            Book myBook = new Book(bookTitle, bookAuthor, pubYear);

            Book secondBook = new Book("The Odyssey", "Homer", "320");

            Book thirdBook = new Book("A World Undone", "G.J. Meyer", "2013");

            BookOrganizer bookLibrary = new BookOrganizer();

            bookLibrary.AddBook(myBook);
            bookLibrary.AddBook(secondBook);
            bookLibrary.AddBook(thirdBook);

            foreach(Book book in bookLibrary.GetBooks)
            {
                Console.WriteLine("--------");
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.PubDate);
                Console.WriteLine("--------");
            }

            Console.WriteLine();
            Console.WriteLine("Removing books now");
            Console.WriteLine();

            bool bookWasRemoved1 = bookLibrary.RemoveBook("Author", "Homer");
            bool bookWasRemoved2 = bookLibrary.RemoveBook("Title", "A World Undone");
            bool bookWasRemoved3 = bookLibrary.RemoveBook("YEAR", "1954");

            foreach(Book book in bookLibrary.GetBooks)
            {
                Console.WriteLine("--------");
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.PubDate);
                Console.WriteLine("--------");
            }

            if(!bookWasRemoved1 || !bookWasRemoved2)
            {
                Console.WriteLine("We did not properly find the book to remove");
            }
        }
    }
}
