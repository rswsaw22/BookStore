using NUnit.Framework;
using bookAppBackend;
using System;

namespace bookAppBackend.UnitTests.BookTest
{
    [TestFixture]
    public class BookTest
    {
        private Book sut;
        private string title = "myBook";
        private string author = "myAuthor";
        private string pubYear = "2020";

        [SetUp]
        public void SetUp()
        {
            sut = new Book(title, author, pubYear);
        }

        [Test]
        public void ShouldGetTitle() 
        {
            string testTitle = sut.Title;
            Assert.AreEqual(testTitle, title, "The title doesn't match what was expected");
        }

        [Test]
        public void ShouldGetAuthor()
        {
            string testAuthor = sut.Author;
            Assert.AreEqual(testAuthor, author, "The author doesn't match what was expected.");
        }

        [Test]
        public void ShouldGetPublicationDate()
        {
            int testPublicationYear = sut.PubDate;
            Assert.AreEqual(testPublicationYear, Int32.Parse(pubYear), "The publication year doesn't match what was expected.");
        }

        [Test]
        public void ShouldSetNewTitle()
        {
            string newTitle = "myNewBook";
            sut.Title = newTitle;
            Assert.AreEqual(sut.Title, newTitle, "The sut did not set the new title.");
        }

        [Test]
        public void ShouldSetNewAuthor()
        {
            string newAuthor = "myNewAuthor";
            sut.Author = newAuthor;
            Assert.AreEqual(sut.Author, newAuthor, "The sut did not set the new author.");
        }

        [Test]
        public void ShouldSetNewPublicationYear()
        {
            int newPubYear = 2018;
            sut.PubDate = newPubYear;
            Assert.AreEqual(sut.PubDate, newPubYear, "The sut did not set the new publication year.");
        }

        [Test]
        public void SetupWrong()
        {
            Book newBook = new Book("secondBook", "secondAuthor", "What error do we get");
            Assert.AreEqual(newBook.PubDate, 0, "The publication year should be zero");
            newBook = null;
        }

        [Test]
        public void NullParametersTest()
        {
            Book newBook = new Book(null, null, "1960");
            Assert.Null(newBook.Title, "Title wasn't null when should have been.");
            Assert.Null(newBook.Author, "Author wasn't null when should have been");
        }

        [TearDown]
        public void TearDown()
        {
            sut = null;
        }
    }
}