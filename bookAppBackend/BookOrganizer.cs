using System;
using System.Collections.Generic;

namespace bookAppBackend
{
    public class BookOrganizer
    {
        private IList<Book> bookList = new List<Book>();

        public void AddBook(Book bookToAdd)
        {
            bookList.Add(bookToAdd);
        }

        public bool RemoveBook(string methodToRemove, string searchValue)
        {
            bool removeResult = false;
            int year;
            IList<Book> removeList = new List<Book>();

            if(bookList.Count == 0)
            {
                Console.WriteLine("Can't remove from an empty list.");
                return removeResult;
            }

            string removeMethod = methodToRemove.ToLower();
            switch(removeMethod)
            {
                case "author":
                    foreach(Book book in bookList)
                    {
                        if(book.Author == searchValue)
                        {
                            removeList.Add(book);
                            removeResult = true;
                        }
                    }
                    break;
                case "title":
                    foreach(Book book in bookList)
                    {
                        if(book.Title == searchValue)
                        {
                            removeList.Add(book);
                            removeResult = true;
                        }
                    }
                    break;
                case "year":
                    try
                    {
                        year = Int32.Parse(searchValue);
                    }
                    catch
                    {
                        Console.WriteLine("FormatException: Please pass in a date.");
                        return removeResult;
                    }
                    foreach(Book book in bookList)
                    {
                        if(book.PubDate == year)
                        {
                            removeList.Add(book);
                            removeResult = true;
                        }
                    }
                    break;
                default:
                    throw new System.ArgumentException("You must provide a method to remove either by: author, title, or year.", "searchValue");
            }

            if(removeResult)
            {
                DeleteBooksFromList(removeList);
            }

            return removeResult;
        }

        public Book FindSpecificBookBySearch(string searchTitle)
        {
            foreach(Book book in bookList)
            {
                if(book.Title == searchTitle)
                {
                    return book;
                }
            }

            return null;
        }

        public IList<Book> FindSpecificBooksByAuthor(string searchAuthor)
        {
            IList<Book> foundBooks = new List<Book>();

            foreach(Book book in bookList)
            {
                if(book.Author == searchAuthor)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        public IList<Book> FindSpecificBooksByYear(string searchYear)
        {
            IList<Book> foundBooks = new List<Book>();

            foreach(Book book in bookList)
            {
                if(book.PubDate.ToString() == searchYear)
                {
                    foundBooks.Add(book);
                }
            }

            return foundBooks;
        }

        private void DeleteBooksFromList(IList<Book> booksToRemove)
        {
            foreach(Book book in booksToRemove)
            {
                bookList.Remove(book);
            }
        }

        public IList<Book> GetBooks
        {
            get => bookList;
        } 
    }
}