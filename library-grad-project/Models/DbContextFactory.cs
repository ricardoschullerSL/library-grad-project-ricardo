namespace LibraryGradProject.Models
{
    public class DbContextFactory
    {
        public LibraryDbContext GetDbContext()
        {
            return new LibraryDbContext();
        }
    }
}