using NUnit.Framework;
using bookAppBackend;
using System;

namespace bookAppBackend.UnitTests.BookOrganizerTest
{
    [TestFixture]
    public class BookOrganizerTest
    {
        private string title = "Foundation";
        private string author = "Asimov";
        private string publicationYear = "1951";

        private BookOrganizer newBookList;

        [SetUp]
        public void SetUp()
        {
            newBookList = new BookOrganizer();
        }

        [Test]
        public void TestAddingABook()
        {
            var testBook = new Book(title, author, publicationYear);
            newBookList.AddBook(testBook);
            Assert.AreEqual(testBook, newBookList.GetBooks[0], "The book added is not the same at the front of the list");
        }

        [Test]
        public void TestRemovingFromListByTitle()
        {
            var testBook = new Book(title, author, publicationYear);
            newBookList.AddBook(testBook);
            Assert.IsNotEmpty(newBookList.GetBooks);
            bool wasRemoved = newBookList.RemoveBook("Title", title);
            Assert.IsEmpty(newBookList.GetBooks);
            Assert.True(wasRemoved);
        }

        [Test]
        public void TestRemovingFromListByAuthor()
        {
            var testBook = new Book(title, author, publicationYear);
            newBookList.AddBook(testBook);
            Assert.IsNotEmpty(newBookList.GetBooks);
            bool wasRemoved = newBookList.RemoveBook("Author", author);
            Assert.IsEmpty(newBookList.GetBooks);
            Assert.True(wasRemoved);
        }

        [Test]
        public void TestRemovingFromListByYear()
        {
            var testBook = new Book(title, author, publicationYear);
            newBookList.AddBook(testBook);
            Assert.IsNotEmpty(newBookList.GetBooks);
            bool wasRemoved = newBookList.RemoveBook("YEAR", publicationYear);
            Assert.IsEmpty(newBookList.GetBooks);
            Assert.True(wasRemoved);
        }

        [Test]
        public void TestRemovingIfListIsEmpty()
        {
            var emptyBookList = new BookOrganizer();
            Assert.IsEmpty(emptyBookList.GetBooks);
            bool wasRemoved = emptyBookList.RemoveBook("Title", title);
            Assert.IsEmpty(emptyBookList.GetBooks);
            Assert.False(wasRemoved);
        }

        [TearDown]
        public void TearDown()
        {
            newBookList = null;
        }
    }
}