using LibraryGradProject.Controllers;
using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using Moq;
using Xunit;
using FakeDbSet;

namespace LibraryGradProjectTests.Controllers
{
    public class BooksControllerTests
    {
        private void Clean()
        {
            var bookCleaner = new InMemoryDbSet<Book>(true);
            var bresCleaner = new InMemoryDbSet<BookReservation>(true);
        }

        [Fact]
        public void Get_Calls_Repo_GetAll()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Book>>();
            mockRepo.Setup(mock => mock.GetAll());
            BooksController controller = new BooksController(mockRepo.Object);

            // Act
            controller.Get();

            // Assert
            mockRepo.Verify(mock => mock.GetAll(), Times.Once);

            // Clean
            Clean();
        }

        [Fact]
        public void Get_With_Id_Calls_Repo_Get()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Book>>();
            mockRepo.Setup(mock => mock.Get(It.IsAny<int>()));
            BooksController controller = new BooksController(mockRepo.Object);

            // Act
            controller.Get(1);

            // Assert
            mockRepo.Verify(mock => mock.Get(It.Is<int>(x => x==1)), Times.Once);

            // Clean
            Clean();
        }

        [Fact]
        public void Post_With_Book_Calls_Repo_Add()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Book>>();
            mockRepo.Setup(mock => mock.Add(It.IsAny<Book>()));
            BooksController controller = new BooksController(mockRepo.Object);

            Book newBook = new Book() { Title = "Test" };

            // Act
            controller.Post(newBook);

            // Assert
            mockRepo.Verify(mock => mock.Add(It.Is<Book>(b => b == newBook)), Times.Once);

            // Clean
            Clean();
        }

        [Fact]
        public void Delete_With_Id_Calls_Repo_Remove()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Book>>();
            mockRepo.Setup(mock => mock.Remove(It.IsAny<int>()));
            BooksController controller = new BooksController(mockRepo.Object);

            // Act
            controller.Delete(1);

            // Assert
            mockRepo.Verify(mock => mock.Remove(It.Is<int>(x => x == 1)), Times.Once);

            // Clean
            Clean();
        }
    }
}