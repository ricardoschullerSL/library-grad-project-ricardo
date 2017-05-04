using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System;
using System.Diagnostics;
using FakeDbSet;

namespace LibraryGradProjectTests.Repos
{
    public class BookRepositoryTests
    {
        private void Clean()
        {
            var bookCleaner = new InMemoryDbSet<Book>(true);
            var bresCleaner = new InMemoryDbSet<BookReservation>(true);
        }
        [Fact]
        public void New_Book_Repository_Is_Empty()
        {
            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);

            // Act
            IEnumerable<Book> books = repo.GetAll();

            // Assert
            Assert.Empty(books);

            // Clean
            Clean();
        }

        [Fact]
        public void Add_Inserts_New_Book()
        {
            // The FakeDbSet gets filled before this test is run, fix this
            Clean();

            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);
            Book newBook = new Book() { Title = "Test" };

            // Act
            repo.Add(newBook);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(new Book[] {newBook}, books.ToArray());

            // Clean
            Clean();
        }

        [Fact]
        public void Add_Sets_New_Id()
        {
            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);
            Book newBook = new Book() { Title = "Test" };

            // Act
            repo.Add(newBook);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(0, books.First().Id);

            // Clean
            Clean();
        }
        /*
        [Fact]
        public void Get_Returns_Specific_Book()
        {
            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);
            Book newBook1 = new Book() { Id = 0, Title = "Test1" };
            Book newBook2 = new Book() { Id = 1, Title = "Test2" };
            repo.Add(newBook1);
            repo.Add(newBook2);

            // Act
            Book book = repo.Get(1);

            // Asert
            Assert.Equal(newBook2, book);

            // Clean
            Clean();
        }*/

        [Fact]
        public void Get_All_Returns_All_Books()
        {
            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);
            Book newBook1 = new Book() { Title = "Test1" };
            Book newBook2 = new Book() { Title = "Test2" };
            repo.Add(newBook1);
            repo.Add(newBook2);

            // Act
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(new Book[] { newBook1, newBook2 }, books.ToArray());

            // Clean
            Clean();
        }

        /*
        [Fact]
        public void Delete_Removes_Correct_Book()
        {
            // Arrange
            var fakeDbFactory = new FakeDbContextFactory();
            BookRepository repo = new BookRepository(fakeDbFactory);
            Book newBook1 = new Book() { Title = "Test1" };
            Book newBook2 = new Book() { Title = "Test2" };
            Book newBook3 = new Book() { Title = "Test3" };
            repo.Add(newBook1);
            repo.Add(newBook2);
            repo.Add(newBook3);

            // Act
            repo.Remove(1);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(new Book[] { newBook1, newBook3 }, books.ToArray());

            // Clean
            Clean();
        }*/
    }
}
