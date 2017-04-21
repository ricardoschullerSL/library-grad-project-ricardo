using LibraryGradProject.Controllers;
using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using Moq;
using Xunit;

namespace LibraryGradProjectTests.Controllers
{
    public class BookReservationsControllerTests
    {
        [Fact]
        public void Get_Calls_Repo_GetAll()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<BookReservation>>();
            mockRepo.Setup(mock => mock.GetAll());
            BookReservationsController controller = new BookReservationsController(mockRepo.Object);

            // Act
            controller.Get();

            // Assert
            mockRepo.Verify(mock => mock.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_With_Id_Calls_Repo_Get()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<BookReservation>>();
            mockRepo.Setup(mock => mock.Get(It.IsAny<int>()));
            BookReservationsController controller = new BookReservationsController(mockRepo.Object);

            // Act
            controller.Get(1);

            // Assert
            mockRepo.Verify(mock => mock.Get(It.Is<int>(x => x == 1)), Times.Once);
        }

        [Fact]
        public void Post_With_Book_Calls_Repo_Add()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<BookReservation>>();
            mockRepo.Setup(mock => mock.Add(It.IsAny<BookReservation>()));
            BookReservationsController controller = new BookReservationsController(mockRepo.Object);

            BookReservation newReservation = new BookReservation() { bookId = 0 };

            // Act
            controller.Post(newReservation);

            // Assert
            mockRepo.Verify(mock => mock.Add(It.Is<BookReservation>(r => r == newReservation)), Times.Once);
        }
        [Fact]
        public void Delete_With_Id_Calls_Repo_Remove()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<BookReservation>>();
            mockRepo.Setup(mock => mock.Remove(It.IsAny<int>()));
            BookReservationsController controller = new BookReservationsController(mockRepo.Object);

            // Act

            controller.Delete(1);

            // Assert
            mockRepo.Verify(mock => mock.Remove(It.Is<int>(x => x == 1)), Times.Once);
        }
    }
}
