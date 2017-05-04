using System.Data.Entity;

namespace LibraryGradProject.Models
{
    public class DbContextFactory
    {
        public virtual ILibraryDbContext GetDbContext()
        {
            return new LibraryDbContext();
        }
    }
}