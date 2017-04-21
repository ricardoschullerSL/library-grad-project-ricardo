using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibraryGradProjectTests.Repos
{
    public class BookReservationRepositoryTests
    {
        [Fact]
        public void New_BookReservation_Repository_Is_Empty()
        {
            // Arrange
            BookReservationRepository repo = new BookReservationRepository();

            // Act
            IEnumerable<BookReservation> bookReservations = repo.GetAll();

            // Assert
            Assert.Empty(bookReservations);

        }

        [Fact]
        public void Add_Inserts_New_Book()
        {
            // Arrange
            BookReservationRepository repo = new BookReservationRepository();
            BookReservation newReservation = new BookReservation() { bookId = 0 };

            // Act
            repo.Add(newReservation);
            IEnumerable<BookReservation> bookReservations = repo.GetAll();

            // Assert
            Assert.Equal(new BookReservation[] { newReservation }, bookReservations.ToArray());

        }
    }
}
