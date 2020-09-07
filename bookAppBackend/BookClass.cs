using System;

namespace bookAppBackend
{
    public class Book
    {
        private string title;
        private string author;
        private int publicationDate;

        public Book(string bookTitle, string bookAuthor, string bookPubDate)
        {
            title = bookTitle;
            author = bookAuthor;
            publicationDate = 0;

            if(bookPubDate != null)
            {
                try
                {
                    publicationDate = Int32.Parse(bookPubDate);
                }
                catch
                {
                    Console.WriteLine("FormatException: Please pass in a date.");
                }
            }
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public int PubDate
        {
            get => publicationDate;
            set => publicationDate = value;
        }
    }
}