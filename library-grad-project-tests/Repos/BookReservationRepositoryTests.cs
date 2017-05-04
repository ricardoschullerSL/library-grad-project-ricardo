using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Data.Entity;
using System;
using FakeDbSet;

namespace LibraryGradProjectTests.Repos
{
    public class BookReservationRepositoryTests
    {
        private void Clean()
        {
            // This clears out the local data stored in RAM

            var bookCleaner = new InMemoryDbSet<Book>(true);
            var bresCleaner = new InMemoryDbSet<BookReservation>(true);
        }
        
        [Fact]
        public void New_BookReservation_Repository_Is_Empty()
        {
            // Arrange
            FakeDbContextFactory fakeDbContextFactory = new FakeDbContextFactory();
            BookReservationRepository repo = new BookReservationRepository(fakeDbContextFactory);

            // Act
            IEnumerable<BookReservation> bookReservations = repo.GetAll();

            // Assert
            Assert.Empty(bookReservations);

            // Clean
            Clean();

        }
        /*
        [Fact]
        public void Add_Inserts_New_BookReservation()
        {
            // Arrange
            FakeDbContextFactory fakeDbContextFactory = new FakeDbContextFactory();
            BookReservationRepository repo = new BookReservationRepository(fakeDbContextFactory);
            BookReservation newReservation = new BookReservation() { BookId = 1 , StartDate = DateTime.Today, EndDate = DateTime.Today};

            // Act
            repo.Add(newReservation);
            IEnumerable<BookReservation> bookReservations = repo.GetAll();

            // Assert
            Assert.Equal(new BookReservation[] { newReservation }, bookReservations.ToArray());
            
            // Clean
            Clean();
        }*/
    }
}
