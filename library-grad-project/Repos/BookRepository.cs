using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace LibraryGradProject.Repos
{
    public class BookRepository : IRepository<Book>
    {
        private DbContextFactory _dbContextFactory;

        public BookRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public void Add(Book entity)
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                db.Books.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                return db.Books.ToList();
            }
        }

        public Book Get(int id)
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                return db.Books.Find(id);
            }
        }

        public void Remove(int id)
        {
            using (ILibraryDbContext db = _dbContextFactory.GetDbContext())
            {
                Book b = db.Books.Find(id);
                db.Books.Remove(b);
                db.SaveChanges();
            }
        }
    }
}