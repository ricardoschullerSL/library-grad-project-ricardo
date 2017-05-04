using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LibraryGradProject.Models;
using FakeDbSet;


namespace LibraryGradProjectTests.Repos
{
    public class FakeDbContext: ILibraryDbContext
    {
        public FakeDbContext()
        {
            this.Books = new InMemoryDbSet<Book>();
            this.BookReservations = new InMemoryDbSet<BookReservation>();
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<BookReservation> BookReservations { get; set; }

        public int SaveChanges()
        {
            int changes = 0;
            return changes;
        }
        public void Dispose()
        {

        }
    }

    public class DbBookSet : InMemoryDbSet<Book>
    {
        
    }
}
