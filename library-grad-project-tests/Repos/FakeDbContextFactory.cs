using System.Data.Entity;
using LibraryGradProject.Models;
using LibraryGradProject.Repos;
namespace LibraryGradProjectTests.Repos
{
    public class FakeDbContextFactory : DbContextFactory
    {
        public override ILibraryDbContext GetDbContext()
        {
            return new FakeDbContext();
        }
    }
}
